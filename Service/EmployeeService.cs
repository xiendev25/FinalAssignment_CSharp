using Data;
using Data.Emtity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class EmployeeService
    {
        private readonly MyDBContext myDBContext;

        public EmployeeService(MyDBContext dbContext)
        {
            myDBContext = dbContext;
        }

        public List<EmployeeDTO> GetAll()
        {
            return myDBContext.Employees
                .OrderBy(e => e.CreatedAt)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Gender = e.Gender,
                    DOB = e.DOB,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    DepartmentId = e.DepartmentId,
                    PositionId = e.PositionId,
                    DepartmentName = e.Department != null ? e.Department.Name : string.Empty,
                    PositionName = e.Position != null ? e.Position.Name : string.Empty
                })
                .ToList();
        }

        public List<EmployeeDTO> Search(string query)
        {
            string queryLower = query.ToLower();
            return myDBContext.Employees
                .Where(e => e.Name.ToLower().Contains(queryLower) ||
                            e.Code.ToLower().Contains(queryLower))
                .OrderBy(e => e.CreatedAt)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Gender = e.Gender,
                    DOB = e.DOB,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    DepartmentId = e.DepartmentId,
                    PositionId = e.PositionId,
                    DepartmentName = e.Department != null ? e.Department.Name : string.Empty,
                    PositionName = e.Position != null ? e.Position.Name : string.Empty
                })
                .ToList();
        }

        public EmployeeDTO? GetByCode(string code)
        {
            return myDBContext.Employees
                .Where(e => e.Code == code)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Gender = e.Gender,
                    DOB = e.DOB,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    DepartmentId = e.DepartmentId,
                    PositionId = e.PositionId,
                    DepartmentName = e.Department != null ? e.Department.Name : string.Empty,
                    PositionName = e.Position != null ? e.Position.Name : string.Empty
                })
                .FirstOrDefault();
        }

        public EmployeeDTO? GetById(int id)
        {
            return myDBContext.Employees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    Gender = e.Gender,
                    DOB = e.DOB,
                    IsActive = e.IsActive,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    DepartmentId = e.DepartmentId,
                    PositionId = e.PositionId,
                    DepartmentName = e.Department != null ? e.Department.Name : string.Empty,
                    PositionName = e.Position != null ? e.Position.Name : string.Empty
                })
                .FirstOrDefault();
        }

        public ServiceResult Add(EmployeeDTO dto)
        {
            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(dto.Name))
                { 
                result.Success = false;
                result.Message = "Tên Nhân sự không được để trống!";
                return result;
            };
            if (string.IsNullOrWhiteSpace(dto.Code))
               {
                    result.Success = false;
                result.Message = "Mã Nhân sự không được để trống!";
                return result;
            };


            if (!myDBContext.Departments.Any(d => d.Id == dto.DepartmentId))
                { 

                    result.Success = false;
                result.Message = "Phòng ban không hợp lệ!";
                return result;
            }
            ;
            if (!myDBContext.Positions.Any(p => p.Id == dto.PositionId))
                return new ServiceResult { Success = false, Message = "Chức danh không hợp lệ!" };

            bool exists = myDBContext.Employees
                .Any(e => e.Code.ToLower() == dto.Code.ToLower());
            if (exists)
            {

                result.Success = false;
                result.Message = "Mã Nhân sự đã tồn tại trong hệ thống!";
                return result;
            }
            ;
            exists = myDBContext.Employees
                .Any(e => e.Name.ToLower() == dto.Name.ToLower());
            if (exists)
            {

                result.Success = false;
                result.Message = "Tên Nhân sự đã tồn tại trong hệ thống!";
                return result;
            }
            ;
            var employee = new Employee
            {
                Code = dto.Code,
                Name = dto.Name,
                Gender = dto.Gender,
                DOB = dto.DOB,
                IsActive = dto.IsActive,
                DepartmentId = dto.DepartmentId,
                PositionId = dto.PositionId,
                CreatedAt = DateTime.Now,
                UpdatedAt = default
            };

            myDBContext.Employees.Add(employee);
            myDBContext.SaveChanges();
            result.Success = true;
            result.Message = "Thêm Nhân sự thành công!";

            return result;
        }

        public ServiceResult Update(EmployeeDTO dto)
        {
            var result = new ServiceResult();


            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                result.Success = false;
                result.Message = "Tên Nhân sự không được để trống!";
                return result;
            }
            ;
            if (string.IsNullOrWhiteSpace(dto.Code))
            {
                result.Success = false;
                result.Message = "Mã Nhân sự không được để trống!";
                return result;
            }
            ;

            if (!myDBContext.Departments.Any(d => d.Id == dto.DepartmentId))
            {

                result.Success = false;
                result.Message = "Phòng ban không hợp lệ!";
                return result;
            }
            ;
            if (!myDBContext.Positions.Any(p => p.Id == dto.PositionId))
                return new ServiceResult { Success = false, Message = "Chức danh không hợp lệ!" };

            bool exists = myDBContext.Employees
                .Where(e => e.Id != dto.Id)
                .Any(e => e.Code.ToLower() == dto.Code.ToLower());
            if (exists)
            {

                result.Success = false;
                result.Message = "Mã Nhân sự đã tồn tại trong hệ thống!";
                return result;
            }
            ;
            exists = myDBContext.Employees
                .Where(e => e.Id != dto.Id)
                .Any(e => e.Name.ToLower() == dto.Name.ToLower());
            if (exists)
            {

                result.Success = false;
                result.Message = "Tên Nhân sự đã tồn tại trong hệ thống!";
                return result;
            }
            ;
            var employee = myDBContext.Employees.SingleOrDefault(e => e.Id == dto.Id);
            if (employee == null)
            {

                result.Success = false;
                result.Message = "Không tồn tại Nhân sự cần cập nhật!";
                return result;
            }

            employee.Code = dto.Code;
            employee.Name = dto.Name;
            employee.Gender = dto.Gender;
            employee.DOB = dto.DOB;
            employee.IsActive = dto.IsActive;
            employee.DepartmentId = dto.DepartmentId;
            employee.PositionId = dto.PositionId;
            employee.UpdatedAt = DateTime.Now;

            myDBContext.SaveChanges();
            result.Success = true;
            result.Message = "Cập nhật Nhân sự thành công!";

            return result;
        }

        public ServiceResult Delete(int id)
        {
            var result = new ServiceResult();

            var employee = myDBContext.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {

                result.Success = false;
                result.Message = "Không tồn tại Nhân sự cần xoá!";
                return result;
            }

            myDBContext.Employees.Remove(employee);
            myDBContext.SaveChanges();
            result.Success = true;
            result.Message = "Xoá Nhân sự thành công!";

            return result;
        }
    }
}
