namespace Library.Data;

public static class DataConstants
{
    public static class Book
    {
        public const int TitleLengthMin = 10;
        public const int TitleLengthMax = 50;
        public const int AuthorLengthMin = 5;
        public const int AuthorLengthMax = 50;
        public const int DescriptionMin = 5;
        public const int DescriptionMax = 5000;
        public const string RatingDecimalMin = "0.00";
        public const string RatingDecimalMax = "10.00";
    }

    public static class Category
    {
        public const int NameLengthMin = 5;
        public const int NameLengthMax = 50;
    }
}