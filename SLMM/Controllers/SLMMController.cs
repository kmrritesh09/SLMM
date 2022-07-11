using Microsoft.AspNetCore.Mvc;

namespace SLMM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SLMMController
    {
        public readonly IConfiguration Configuration;
        public static int Length = 10;
        public static int Breadth = 10;
        public static int xAxisPosition;
        public static int yAxisPosition;
        public static Compass currentDirection;

        public SLMMController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost(Name = "ResetField")]
        public SLMMLawnPosition SetAreaOfFieldAndResetSLMM(int length, int breadth)
        {
            Length = length;
            Breadth = breadth;
            xAxisPosition = Convert.ToInt32(Configuration["X-Axis"]);
            yAxisPosition = Convert.ToInt32(Configuration["Y-Axis"]);
            string Configdirection = Configuration["Direction"];
            Enum.TryParse(Configdirection, out currentDirection);

            return new SLMMLawnPosition()
            {
                xAxisPosition = xAxisPosition,
                yAxisPosition = yAxisPosition,
                direction = currentDirection.ToString(),
                SetLength = length,
                SetBreadth = breadth,
            };
        }

        [HttpGet(Name = "MoveLawnMower")]
        public LawnMowerPosition MoveLawnMower(int instruction)
        {
            switch(instruction)
            {
                case (int)Instructions.Turn90clockwise:
                    SetNewDirectionAfterClockwise();
                    Thread.Sleep(2000);
                    break;
                case (int)Instructions.Turn90anticlockwise:
                    SetNewDirectionAfterAntiClockwise();
                    Thread.Sleep(2000);
                    break;
                case (int)Instructions.Moveonestepforward:
                    if(!CheckIfForwardMovementPossible())
                    {
                        throw new Exception("Invalid command for current position of SLMM");
                    }
                    MoveSLMMBySingleStep();
                    Thread.Sleep(5000);
                    break;
                default:
                    throw new Exception("Error in Instruction");
            }

            LawnMowerPosition lawnMowerPosition = new LawnMowerPosition()
            {
                xAxisPosition = xAxisPosition,
                yAxisPosition = yAxisPosition,
                direction = currentDirection.ToString(),
            };

            return lawnMowerPosition;
        }

        private bool CheckIfForwardMovementPossible()
        {
            bool commandPossible = true;

            switch (currentDirection)
            {
                case Compass.East:
                    if (xAxisPosition == Length)
                        commandPossible = false;
                    break;
                case Compass.West:
                    if (xAxisPosition == 0)
                        commandPossible = false;
                    break;
                case Compass.North:
                    if (yAxisPosition == Breadth)
                        commandPossible = false;
                    break;
                case Compass.South:
                    if (yAxisPosition == 0)
                        commandPossible = false;
                    break;
                default:
                    break;
            }

            return commandPossible;
        }

        private void SetNewDirectionAfterClockwise()
        {
            switch(currentDirection)
            {
                case Compass.East:
                    currentDirection = Compass.South;
                    break;
                case Compass.West:
                    currentDirection = Compass.North;
                    break;
                case Compass.North:
                    currentDirection = Compass.East;
                    break;
                case Compass.South:
                    currentDirection = Compass.West;
                    break;
                default:
                    break;
            }
        }

        private void SetNewDirectionAfterAntiClockwise()
        {
            switch (currentDirection)
            {
                case Compass.East:
                    currentDirection = Compass.North;
                    break;
                case Compass.West:
                    currentDirection = Compass.South;
                    break;
                case Compass.North:
                    currentDirection = Compass.West;
                    break;
                case Compass.South:
                    currentDirection = Compass.East;
                    break;
                default:
                    break;
            }
        }

        private void MoveSLMMBySingleStep()
        {
            switch (currentDirection)
            {
                case Compass.East:
                    xAxisPosition += 1;
                    break;
                case Compass.West:
                    xAxisPosition -= 1;
                    break;
                case Compass.North:
                    yAxisPosition += 1;
                    break;
                case Compass.South:
                    yAxisPosition -= 1;
                    break;
                default:
                    break;
            }
        }

    }
}
