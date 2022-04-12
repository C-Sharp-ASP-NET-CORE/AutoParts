namespace AutoParts.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Part
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(PartNameMaxLength,MinimumLength = PartNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(PartSerialNumberMaxLength, MinimumLength = PartSerialNumberMinLength)]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(PartManufacturerMaxLength, MinimumLength = PartManufacturerMinLength)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(PartCarBrandMaxLength,MinimumLength =PartCarBrandMinLength)]
        public string CarBrand { get; set; }

        [Required]
        [StringLength(PartCarModelMaxLength,MinimumLength = PartCarModelMinLength)]
        public string CarModel { get; set; }

        [Range(typeof(decimal), PartPriceMinLength, PartPriceMaxLength)]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public bool IsUserd { get; set; }

        [Required]
        [StringLength(PartDescriptionMaxLength,MinimumLength =PartDescriptionMinLength)]
        public string Description { get; set; }

        public IList<StoreHouse> StoreHouses { get; set; } = new List<StoreHouse>();

        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
