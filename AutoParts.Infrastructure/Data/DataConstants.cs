namespace AutoParts.Infrastructure.Data
{
    public class DataConstants
    {
        public const int CategoryNameMaxLength = 20;

        public const int PartNameMinLength = 2;
        public const int PartNameMaxLength = 50;
        public const int PartSerialNumberMinLength = 5;
        public const int PartSerialNumberMaxLength = 50;
        public const int PartManufacturerMinLength = 2;
        public const int PartManufacturerMaxLength = 50;
        public const int PartCarBrandMinLength = 2;
        public const int PartCarBrandMaxLength = 20;
        public const int PartCarModelMinLength = 2;
        public const int PartCarModelMaxLength = 20;
        public const int PartDescriptionMinLength = 4;
        public const int PartDescriptionMaxLength = 10000;
        public const string PartPriceMinLength = "0";
        public const string PartPriceMaxLength = "50000";

        public const int ContragentCustomerNumberMaxLength = 20;
        public const int ContragentNameMaxLength = 200;
        public const int ContragentIdentifierMaxLength = 200;
        public const int ContragentAddressMaxLength = 200;
        public const int ContragentLoyaltyCardMaxLength = 200;

        public const int StoreHouseNumberMaxLength = 5;
        public const int StoreHouseSectionMaxLength = 5;
    }
}
