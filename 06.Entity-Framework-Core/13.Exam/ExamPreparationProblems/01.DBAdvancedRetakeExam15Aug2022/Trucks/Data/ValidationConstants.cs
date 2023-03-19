namespace Trucks.Data;

public class ValidationConstants
{
    public const int truckLength = 8;
    public const int vinLength = 17;

    public const int clientNameMaxLength = 40;
    public const int clientNameMinLength = 3;
    public const int clientMaxNationality= 40;
    public const int clientMinNationality= 2;

    public const int despatcherMaxNameLength= 40;
    public const int despatcherMinNameLength= 2;

    public const int tankCapacityMin = 950;
    public const int tankCapacityMax = 1420;

    public const int cargoCapacityMin = 5000;
    public const int cargoCapacityMax = 29000;

    public const int makeTypeMin = 0;
    public const int makeTypeMax = 4;

    public const int categoryTypeMin = 0;
    public const int categoryTypeMax = 3;
}