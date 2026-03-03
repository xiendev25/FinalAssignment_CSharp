using Data;
using Data.Emtity;
using DTO;

namespace Service
{
    public class AttendanceService
    {
        private readonly MyDBContext myDBContext;

        public AttendanceService(MyDBContext dbContext)
        {
            this.myDBContext = dbContext;
        }

        public List<AttendanceDTO> GetAll()
        {
            return myDBContext.Attendances
                .OrderByDescending(a => a.WorkDate)
                .ThenByDescending(a => a.CreatedAt)
                .Select(a => new AttendanceDTO
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    EmployeeCode = a.Employee.Code,
                    WorkDate = a.WorkDate,
                    CheckIn = a.CheckIn,
                    CheckOut = a.CheckOut,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                })
                .ToList();
        }

        public List<AttendanceDTO> GetAttendanceToday(DateOnly date)
        {
            return myDBContext.Attendances
                .OrderByDescending(a => a.WorkDate)
                .ThenByDescending(a => a.CreatedAt)
                .Where(a => a.WorkDate == date)
                .Select(a => new AttendanceDTO
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    EmployeeCode = a.Employee.Code,
                    WorkDate = a.WorkDate,
                    CheckIn = a.CheckIn,
                    CheckOut = a.CheckOut,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                })
                .ToList();
        }

        public List<AttendanceDTO> Search(string query)
        {
            string q = (query ?? string.Empty).ToLower();
            return myDBContext.Attendances
                .Where(a => a.Employee.Code.ToLower().Contains(q))
                .OrderByDescending(a => a.WorkDate)
                .Select(a => new AttendanceDTO
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    EmployeeCode = a.Employee.Code,
                    WorkDate = a.WorkDate,
                    CheckIn = a.CheckIn,
                    CheckOut = a.CheckOut,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                })
                .ToList();
        }

        public ServiceResult CheckIn(string employeeCode)
        {
            var result = new ServiceResult();
            if (string.IsNullOrWhiteSpace(employeeCode))
            {
                result.Success = false;
                result.Message = "Vui lòng nhập Mã nhân sự hợp lệ!";
                return result;
            }

            var emp = myDBContext.Employees.SingleOrDefault(e => e.Code == employeeCode);
            if (emp == null)
            {
                result.Success = false;
                result.Message = "Nhân sự không tồn tại!";
                return result;
            }

            var today = DateOnly.FromDateTime(DateTime.Now);
            var now = DateTime.Now;

            var exists = myDBContext.Attendances
                .SingleOrDefault(a => a.Employee.Code == emp.Code && a.WorkDate == today);

            if (exists != null && exists.CheckIn != null)
            {
                result.Success = false;
                result.Message = "Nhân sự này đã Check In hôm nay!";
                return result;
            }

            var attendace = new Attendance
            {
                EmployeeId = emp.Id,
                WorkDate = today,
                CheckIn = TimeOnly.FromDateTime(now),
                CreatedAt = now,
                UpdatedAt = now
            };
            myDBContext.Attendances.Add(attendace);

            myDBContext.SaveChanges();
            result.Success = true;
            result.Message = "Check In thành công!";
            return result;
        }

        public ServiceResult CheckOut(string employeeCode)
        {
            var result = new ServiceResult();
            if (string.IsNullOrWhiteSpace(employeeCode))
            {
                result.Success = false;
                result.Message = "Vui lòng nhập Mã nhân sự hợp lệ!";
                return result;
            }

            var emp = myDBContext.Employees.SingleOrDefault(e => e.Code == employeeCode);
            if (emp == null)
            {
                result.Success = false;
                result.Message = "Nhân sự không tồn tại!";
                return result;
            }

            var today = DateOnly.FromDateTime(DateTime.Now);
            var now = DateTime.Now;

            var attendance = myDBContext.Attendances
                .SingleOrDefault(a => a.Employee.Code == emp.Code && a.WorkDate == today);

            if (attendance == null || attendance.CheckIn == null)
            {
                result.Success = false;
                result.Message = "Nhân sự này chưa Check In hôm nay!";
                return result;
            }

            if (attendance.CheckOut != null)
            {
                result.Success = false;
                result.Message = "Nhân sự này đã Check Out hôm nay!";
                return result;
            }

            attendance.CheckOut = TimeOnly.FromDateTime(now);
            attendance.UpdatedAt = now;

            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Check Out thành công!";
            return result;

        }

        public ServiceResult Delete(int id)
        {
            var result = new ServiceResult();
            var entity = myDBContext.Attendances.SingleOrDefault(a => a.Id == id);
            if (entity == null)
            {
                result.Success = false;
                result.Message = "Không tồn tại bản ghi chấm công cần xoá!";
                return result;
            }    

            myDBContext.Attendances.Remove(entity);
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Xoá chấm công thành công!";
            return result;
        }
    }
}
