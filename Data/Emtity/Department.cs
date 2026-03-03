using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Emtity
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]

        public string Code { get; set; } = null!;

        [StringLength(100)]

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
