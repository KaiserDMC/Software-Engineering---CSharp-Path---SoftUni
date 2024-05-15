namespace Contacts.Data;

public static class DataConstants
{
    public static class Contact
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;
        public const int LastNameMinLength = 5;
        public const int LastNameMaxLength = 50;
        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;
        public const int PhoneNumberMinLength = 10;
        public const int PhoneNumberMaxLength = 13;
        public const string WebsiteRegEx = @"^www\.[A-Za-z0-9]+\.bg$";
    }
}