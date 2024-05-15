namespace Boardgames.DataProcessor;

public class ValidationConstants
{
    //Creator
    public const int CreatorAnyNameLengthMin = 2;
    public const int CreatorAnyNameLengthMax = 7;

    //Boardgame
    public const int BoardgameNameLengthMin = 10;
    public const int BoardgameNameLengthMax = 20;
    public const double BoardgameRatingRangeMin = 1;
    public const double BoardgameRatingRangeMax = 10;
    public const int BoardgameYearRangeMin = 2018;
    public const int BoardgameYearRangeMax = 2023;

    //Seller
    public const int SellerNameLengthMin = 5;
    public const int SellerNameLengthMax = 20;
    public const int SellerAddressLengthMin = 2;
    public const int SellerAddressLengthMax = 30;
    public const string SellerWebsiteRegex = @"www\.[A-Za-z\d\-]+\.com";
}