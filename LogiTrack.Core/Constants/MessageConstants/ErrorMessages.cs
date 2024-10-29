namespace LogiTrack.Core.Constants.MessageConstants
{
    public static class ErrorMessages
    {
        public const string RequiredFieldErrorMessage = "{0} is required.";
        public const string InvalidEmailErrorMessage = "Email address is invalid.";
        public const string InvalidAddressErrorMessage = "Address is invalid.";
        public const string InvalidLoginAttemptErrorMessage = "Invalid login attempt.";
        public const string LengthErrorMessage = "{0} should be between {2} and {1} characters.";
        public const string EmailAlreadyExistsErrorMessage = "User with this email already exists.";
        public const string PhoneNumberAlreadyExistsErrorMessage = "User with this phone number already exists.";
        public const string UserNotFoundErrorMessage = "User not found.";
        public const string ClientCompanyNotFoundErrorMessage = "Client company not found.";
        public const string VehicleNotFoundErrorMessage = "Vehicle not found.";
        public const string InvalidPriceErrorMessage = "Invalid price.";
        public const string DeliveryNotFoundErrorMessage = "Delivery not found.";
        public const string InvalidAmountErrorMessage = "Invalid amount.";
        public const string PasswordsDoNotMatchErrorMessage= "Passwords do not match.";
        public const string NewPasswordLikeCurrentPasswordErrorMessage = "New password cannot be the same as the current password.";
        public const string OfferNotFoundErrorMessage = "Offer not found.";
        public const string CompanyDoesNotHaveOfferErrorMessage = "Company does not have this offer.";
        public const string DriverNotFoundErrorMessage = "Driver not found.";
        public const string DriverDoesNotHaveDeliveryErrorMessage = "Driver does not have this delivery.";
        public const string LicenseExpirationErrorMessage = "Your driver's license will expire soon.";
        public const string InvalidCoordinatesErrorMessage = "Invalid coordinates.";
        public const string InvoiceNotFoundErrorMessage = "Invoice not found.";
    }
}
