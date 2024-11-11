namespace LogiTrack.Infrastructure.Data.DataConstants
{
    public static class DataModelConstants
    {
        public static class ClientCompany
        {
            public const int CompanyNameMaxLength = 100;
            public const int CompanyNameMinLength = 0;
            public const int RegistrationStatusMaxLength = 10;
            public const int RegistrationStatusMinLength = 0;
            public const int ContactPersonMaxLength = 100;
            public const int ContactPersonMinLength = 0;
            public const int PhoneNumberMaxLength = 10;
            public const int PhoneNumberMinLength = 0;
            public const int RegistrationNumberMaxLength = 9;
            public const int RegistrationNumberMinLength = 9;
            public const int IndustryMaxLength = 100;
            public const int IndustryMinLength = 0;
            public const int StreetMaxLength = 100;
            public const int StreetMinLength = 0;
            public const int CityMaxLength = 40;
            public const int CityMinLength = 0;
            public const int CountryMaxLength = 40;
            public const int CountryMinLength = 0;
            public const int PostalCodeMaxLength = 4;
            public const int PostalCodeMinLength = 4;
        }

        public static class Request
        {
            public const int TypeOfGoodsMaxLength = 50;
            public const int TypeOfGoodsMinLength = 0;
            public const int PriceMaxValue = 200000;
            public const int PriceMinValue = 0;
            public const int RequestStatusMaxLength = 10;
            public const int RequestStatusMinLength = 0;
            public const int SpecialInstructionsMaxLength = 1000;
            public const int SpecialInstructionsMinLength = 0;
            public const int RequestTypeMaxLength = 20;
            public const int RequestTypeMinLength = 0;
            public const int CargoTypeMaxLength = 20;
            public const int CargoTypeMinLength = 0;
            public const int TypeOfPalletMaxLength = 20;
            public const int TypeOfPalletMinLength = 0;
            public const int NumberOfPalletsMaxValue = 50;
            public const int NumberOfPalletsMinValue = 0;
            public const double PalletMetricsMaxValue = 120.0;
            public const double PalletMetricsValue = 0.0;
            public const double PalletVolumeMaxValue = 2000.0;
            public const double PalletVolumeMinValue = 0.0;
            public const double PalletWeightMaxValue = 2000.0;
            public const double PalletWeightMinValue = 0.0;
            public const double GoodsWeightMaxValue = 2000.0;
            public const double GoodsWeightMinValue = 0.0;
            public const double GoodsVolumeMaxValue = 2000.0;
            public const double GoodsVolumeMinValue = 0.0;
            public const double GoodsMetricsMaxValue = 200.0;
            public const double GoodsMetricsMinValue = 0.0;
            public const int NumberOfNonStandartGoodsMaxValue = 10;
            public const int NumberOfNonStandartGoodsMinValue = 0;
            public const double LatitudeMaxValue = 90.0;
            public const double LatitudeMinValue = -90.0;
            public const double LongitudeMaxValue = 180.0;
            public const double LongitudeMinValue = -180.0;
            public const int AddressMaxLength = 200;
            public const int AddressMinLength = 0;
        }

        public static class Offer
        {
            public const int OfferStatusMaxLength = 10;
            public const int OfferStatusMinLength = 0;
            public const int PriceMaxValue = 200000;
            public const int PriceMinValue = 0;
            public const int NotesMaxLength = 1000;
            public const int NotesMinLength = 0;
        }

        public static class Vehicle
        {
            public const double MetricsMinValue = 0.0;
            public const double MetricsMaxValue = 100.0;
            public const int PalletCapacityMinValue = 0;
            public const int PalletCapacityMaxValue = 100;
            public const int RegistartionNumberMaxLength = 8;
            public const int RegistartionNumberMinLength = 8;
            public const double FuelConsumptionMinValue = 0.0;
            public const double FuelConsumptionMaxValue = 20.0;
            public const int VehicleStatusMaxLength = 20;
            public const int VehicleStatusMinLength = 0;
            public const int VehicleTypeMaxLength = 20;
            public const int VehicleTypeMinLength = 0;
            public const double VolumeMinValue = 0.0;
            public const double VolumeMaxValue = 2000.0;
            public const double PriceMinValue = 0.0;
            public const double PriceMaxValue = 20000.0;
            public const double KilometersMinValue = 0.0;
            public const double KilometersMaxValue = 1000000.0;
        }

        public static class Driver
        {
            public const int AgeMaxValue = 64;
            public const int AgeMinValue = 18;
            public const int DriverNameMaxLength = 100;
            public const int DriverNameMinLength = 0;
            public const int DriverLicenceNumberMaxLength = 10;
            public const double SalaryMinValue = 0.0;
            public const double SalaryMaxValue = 10000.0;
            public const int YearOfExperienceMaxValue = 56;
            public const int YearOfExperienceMinValue = 0;
            public const int MonthsOfExperienceMaxValue = 672;
            public const int MonthsOfExperienceMinValue = 0;
            public const int PreferrencesMaxLength = 1000;
            public const int PreferrencesMinLength = 0;
        }

        public static class Delivery
        {
            public const int DeliveryStatusMaxLength = 20;
            public const int DeliveryStatusMinLength = 0;
            public const double DeliveryPriceMinValue = 0.0;
            public const double DeliveryPriceMaxValue = 200000.0;
            public const int ReferenceNumberMaxLength = 20;
            public const int ReferenceNumberMinLength = 0;
        }

        public static class CashRegister
        {
            public const int RegisterDescriptionMaxLength = 1000;
            public const int RegisterDescriptionMinLength = 0;
            public const int RegisterTypeMaxLength = 20;
            public const int RegisterTypeMinLength = 0;
            public const double RegisterAmountMinValue = 0.0;
            public const double RegisterAmountMaxValue = 10000.0;
        }
        public static class DeliveryTracking
        {
            public const int TrackingStatusMaxLength = 30;
            public const int TrackingStatusMinLength = 0;
            public const int TrackingNotesMaxLength = 1000;
            public const int TrackingNotesMinLength = 0;
            public const double LatitudeMaxValue = 90.0;
            public const double LatitudeMinValue = -90.0;
            public const double LongitudeMaxValue = 180.0;
            public const double LongitudeMinValue = -180.0;
        }

        public static class PricePerSize
        {
            public const double PriceMinValue = 0.0;
            public const double PriceMaxValue = 100.0;
            public const double QuotientMinValue = 0.0;
            public const double QuotientMaxValue = 10.0;
        }

        public static class FuelPrice
        {
            public const double PriceMinValue = 0.0;
            public const double PriceMaxValue = 20.0;
        }

        public static class CalendarEvent
        {
            public const int EventTypeMaxLength = 20;
            public const int EventTypeMinLength = 0;
            public const int EventTitleMaxLength = 100;
            public const int EventTitleMinLength = 0;
        }
        public static class Address
        {
            public const int StreetMaxLength = 100;
            public const int StreetMinLength = 0;
            public const int CityMaxLength = 40;
            public const int CityMinLength = 0;
            public const int CountryMaxLength = 40;
            public const int CountryMinLength = 0;
            public const int PostalCodeMaxLength = 5;
            public const int PostalCodeMinLength = 5;
            public const double LatitudeMaxValue = 90.0;
            public const double LatitudeMinValue = -90.0;
            public const double LongitudeMaxValue = 180.0;
            public const double LongitudeMinValue = -180.0;
        }
        public static class SearchTerm
        {
            public const int SearchTermMaxLength = 20;
            public const int SearchTermMinLength = 0;
        }
    }
}
