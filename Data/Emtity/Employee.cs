using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Emtity
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]

        public string Code { get; set; } = null!;

        [StringLength(100)]

        public string Name { get; set; } = null!;

        public int Gender { get; set; }

        public DateOnly DOB { get; set; } 

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public int DepartmentId { get; set; }

        public int PositionId { get; set; }

        [ForeignKey("DepartmentId")]

        public Department? Department { get; set; }


        [ForeignKey("PositionId")]

        public Position? Position { get; set; }
    }
}
