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
        [StringLength(PartNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(PartSerialNumberLength)]
        public string SerialNumber { get; set; }
        [Required]
        [StringLength(PartManufacturerMaxLength)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(PartCarBrandMaxLength)]
        public string CarBrand { get; set; }

        [Required]
        [StringLength(PartCarModelMaxLength)]
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
        [StringLength(PartDescriptionMaxLength)]
        public string Description { get; set; }

        public IList<StoreHouse> StoreHouses { get; set; } = new List<StoreHouse>();

        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
