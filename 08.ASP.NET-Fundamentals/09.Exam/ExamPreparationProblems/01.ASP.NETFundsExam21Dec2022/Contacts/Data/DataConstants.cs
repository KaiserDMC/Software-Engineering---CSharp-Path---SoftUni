namespace Contacts.Data;

public static class DataConstants
{
    public static class ApplicationUser
    {
        public const int UsernameLengthMin = 5;
        public const int UsernameLengthMax = 20;
        public const int EmailLengthMin = 10;
        public const int EmailLengthMax = 60;
        public const int PasswordLengthMin = 5;
        public const int PasswordLengthMax = 20;
    }

    public static class Contact
    {
        public const int FirstNameLengthMin = 2;
        public const int FirstNameLengthMax = 50;
        public const int LastNameLengthMin = 5;
        public const int LastNameLengthMax = 50;
        public const int EmailLengthMin = 10;
        public const int EmailLengthMax = 60;
        public const string PhoneNumberRegEx = @"^(?:\+359|0)\s?\d{3}(?:\s|-)?\d{2}(?:\s|-)?\d{2}(?:\s|-)?\d{2}$";
        public const int PhoneNumberMax = 13;
        public const string WebsiteRegEx = @"^www\.[A-Za-z0-9]+\.bg$";
    }
}