using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts.Infrastructure.Data.Models
{
    using static DataConstants;
    public class StoreHouse
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(StoreHouseNumberMaxLength)]
        public string Number { get; set; }

        [Required]
        [StringLength(StoreHouseSectionMaxLength)]
        public string Section { get; set; }

        public bool IsInUse { get; set; } = true;

        public int PartsCount { get; set; } = 0;

        public Guid PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
    }
}