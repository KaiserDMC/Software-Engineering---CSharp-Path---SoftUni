namespace Footballers.Data;

public class ValidationConstants
{
    public const int CoachNameLengthMin = 2;
    public const int CoachNameLengthMax = 40;

    public const int FootballerNameLengthMin = 2;
    public const int FootballerNameLengthMax = 40;

    public const string TeamNameRegexValidation = @"[A-Za-z\d\.\- ]{3,40}";

    public const int TeamNationalityLengthMin = 2;
    public const int TeamNationalityLengthMax = 40;
}