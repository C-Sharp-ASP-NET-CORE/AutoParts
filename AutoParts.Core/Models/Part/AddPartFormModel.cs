using AutoParts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Core.Models.Part
{
    using static DataConstants;
    public class AddPartFormModel
    {
        [Required]
        [StringLength(PartNameMaxLength, MinimumLength = PartNameMinLength)]
        public string Name { get; init; }
        [DisplayName("Serial Number")]
        [Required]
        [StringLength(30)]
        public string SerialNumber { get; init; }
        [Required]
        [StringLength(30)]
        public string Manufacturer { get; init; }
        [DisplayName("Car Brand")]
        [Required]
        [StringLength(30)]
        public string CarBrand { get; init; }
        [DisplayName("Car Model")]
        [Required]
        [StringLength(30)]
        public string CarModel { get; init; }
        [Required]
        [Range(typeof(decimal), PartPriceMinLength, PartPriceMaxLength)]
        public string Price { get; init; }

        [DisplayName("Year")]
        [Required]
        public string Date { get; set; }
        [Required]
        [Url]
        [DisplayName("Image URL")]
        public string ImageUrl { get; init; }
        [DisplayName("Is your product used?")]
        public bool IsUserd { get; init; }
        [Required]
        [StringLength(500)]
        public string Description { get; init; }
        [DisplayName("Categories")]
        public int CategoryId { get; init; }
        public IEnumerable<PartCategoryViewModel> Categories { get; set; }
    }
}
