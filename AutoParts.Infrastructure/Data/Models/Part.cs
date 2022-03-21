
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

        [Range(typeof(decimal), PartWeightMinLength, PartWeightMaxLength)]
        public double Weight { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public bool IsUserd { get; set; }

        [Required]
        [StringLength(PartDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
