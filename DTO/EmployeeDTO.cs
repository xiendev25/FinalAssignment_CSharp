using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int Gender { get; set; }

        public string? GenderName => this.Gender == 0 ? "Nam" : "Nữ";

        public DateOnly DOB { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int DepartmentId { get; set; }

        public int PositionId { get; set; } 

        public string? DepartmentName { get; set; }
        public string? PositionName { get; set; }

        
    }
}
