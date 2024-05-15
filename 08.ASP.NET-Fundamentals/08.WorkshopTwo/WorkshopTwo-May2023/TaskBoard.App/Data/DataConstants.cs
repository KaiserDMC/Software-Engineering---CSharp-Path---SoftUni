namespace TaskBoard.App.Data;

public static class DataConstants
{
    public static class Task
    {
        public const int TaskTitleMax = 70;
        public const int TaskTitleMin = 5;
        public const int TaskDescriptionMax = 1000;
        public const int TaskDescriptionMin = 10;
    }

    public static class Board
    {
        public const int BoardNameMax = 30;
        public const int BoardNameMin = 3;
    }
}