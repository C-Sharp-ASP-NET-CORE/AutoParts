namespace AutoParts.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
