using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Core.Models.Part
{
    public class PartListingViewModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string CarBrand { get; init; }
        public string CarModel { get; init; }
        public string ImageUrl { get; init; }
        public string Category { get; init; }
    }
}
