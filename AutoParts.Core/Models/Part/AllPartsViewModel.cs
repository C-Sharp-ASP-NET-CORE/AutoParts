using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Core.Models.Part
{
    public class AllPartsViewModel
    {
        public const int PartsPerPage = 6;
        public int CurrentPage { get; init; } = 1;
        public int TotalParts { get; set; }
        public string Brand { get; init; }
        public IEnumerable<string> Brands { get; init; }

        [Display(Name ="Search")]
        public string SearchTerm { get; init; }
        public IEnumerable<PartListingViewModel> Parts { get; init; }
    }
}
