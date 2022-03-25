namespace AutoParts.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Contragent
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(ContragentCustomerNumberMaxLength)]
        public string CustomerNumber { get; set; }

        [Required]
        [StringLength(ContragentNameMaxLength)]
        public string Name { get; set; }

        [StringLength(ContragentIdentifierMaxLength)]
        public string? Identifier { get; set; }

        [StringLength(ContragentAddressMaxLength)]
        public string? Address { get; set; }

        [StringLength(ContragentLoyaltyCardMaxLength)]
        public string? LoyaltyCard { get; set; }

        public IList<Deal> Deals { get; set; } = new List<Deal>();
    }
}