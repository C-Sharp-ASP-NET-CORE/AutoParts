namespace AutoParts.Infrastructure.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DealSubject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid DealId { get; set; }

        public Guid PartId { get; set; }

        public int PartCount { get; set; }

        [ForeignKey(nameof(DealId))]
        public Deal Deal { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
    }
}