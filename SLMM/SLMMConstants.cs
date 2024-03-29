﻿namespace SLMM
{
    public class SLMMConstants
    {
        public const string WestMovementExceptionMessage = "Invalid command as lawn mower cannot go beyond 0 x-axis position of field";

        public const string EastMovementExceptionMessage = "Invalid command as lawn mower cannot go beyond length of field";

        public const string NorthMovementExceptionMessage = "Invalid command as lawn mower cannot go beyond breadth of field";

        public const string SouthMovementExceptionMessage = "Invalid command as lawn mower cannot go beyond 0 y-axis position of field";

        public static string InvalidInstructionError = "Error in Instruction. Please enter 0 for clockwise, 1 for anti-clockwise and 2 to move forward";

        public const int DirectionMovementWaitTimeInMs = 2000;

        public const int ForwardMovementWaitTimeInMs = 5000;
    }
}
