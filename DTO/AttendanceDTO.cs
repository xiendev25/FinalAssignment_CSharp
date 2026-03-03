using Data.Emtity;

namespace DTO
{
    public class AttendanceDTO
    {
        public int Id { get; set; }

        public string EmployeeCode { get; set; }

        public int? EmployeeId { get; set; }

        public DateOnly WorkDate { get; set; }

        public TimeOnly? CheckIn { get; set; }

        public TimeOnly? CheckOut { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Employee Employee { get; set; }
    }
}
