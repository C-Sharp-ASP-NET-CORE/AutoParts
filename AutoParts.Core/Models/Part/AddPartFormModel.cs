using AutoParts.Infrastructure.Data;
using AutoParts.Infrastructure.Data.Models;
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
        [StringLength(PartSerialNumberMaxLength,MinimumLength =PartSerialNumberMinLength)]
        public string SerialNumber { get; init; }

        [Required]
        [StringLength(PartManufacturerMaxLength,MinimumLength =PartManufacturerMinLength)]
        public string Manufacturer { get; init; }

        [DisplayName("Car Brand")]
        [Required]
        [StringLength(PartCarBrandMaxLength, MinimumLength = PartCarBrandMinLength)]
        public string CarBrand { get; init; }

        [DisplayName("Car Model")]
        [Required]
        [StringLength(PartCarModelMaxLength, MinimumLength = PartCarModelMinLength)]
        public string CarModel { get; init; }

        [Required]
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
        [StringLength(PartDescriptionMaxLength, MinimumLength = PartDescriptionMinLength)]
        public string Description { get; init; }

        [DisplayName("Categories")]
        public Guid CategoryId { get; init; }
        public IEnumerable<PartCategoryViewModel> Categories { get; set; }
    }
}
