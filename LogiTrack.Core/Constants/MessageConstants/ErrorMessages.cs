namespace LogiTrack.Core.Constants.MessageConstants
{
    public static class ErrorMessages
    {
        public const string RequiredFieldErrorMessage = "{0} is required.";
        public const string InvalidEmailErrorMessage = "Email address is invalid.";
        public const string InvalidLoginAttemptErrorMessage = "Invalid login attempt.";
        public const string LengthErrorMessage = "{0} should be between {2} and {1} characters.";
        public const string EmailAlreadyExistsErrorMessage = "User with this email already exists.";
        public const string PhoneNumberAlreadyExistsErrorMessage = "User with this phone number already exists.";
        public const string UserNotFoundErrorMessage = "User not found.";
        public const string ClientCompanyNotFoundErrorMessage = "Client company not found.";
    }
}
