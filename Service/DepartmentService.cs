using Data;
using Data.Emtity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DepartmentService
    {
        private readonly MyDBContext myDBContext;

        public DepartmentService(MyDBContext dbContext)
        {
            this.myDBContext = dbContext;
        }

        public List<DepartmentDTO> GetAll()
        {
            return myDBContext.Departments
                .OrderBy(d => d.CreatedAt)
                .Select(d => new DepartmentDTO
                {
                    Id = d.Id,
                    Code = d.Code,
                    Name = d.Name,
                    IsActive = d.IsActive,
                    CreatedAt = d.CreatedAt,
                    UpdatedAt = d.UpdatedAt
                }).ToList();
        }

        public List<DepartmentDTO> Search(string query)
        {
            string queryLower = query.ToLower();
            return myDBContext.Departments
                .Where(d => d.Name.ToLower().Contains(queryLower) ||
                            d.Code.ToLower().Contains(queryLower))
                .OrderBy(d => d.CreatedAt)
                .Select(d => new DepartmentDTO
                {
                    Id = d.Id,
                    Code = d.Code,
                    Name = d.Name,
                    IsActive = d.IsActive,
                    CreatedAt = d.CreatedAt,
                    UpdatedAt = d.UpdatedAt
                })
                .ToList();
        }

        public DepartmentDTO? GetById(int id)
        {
            return myDBContext.Departments
                .Where(d => d.Id == id)
                .Select(d => new DepartmentDTO
                {
                    Id = d.Id,
                    Code = d.Code,
                    Name = d.Name,
                    IsActive = d.IsActive,
                    CreatedAt = d.CreatedAt,
                    UpdatedAt = d.UpdatedAt
                }).FirstOrDefault();
        }

        public ServiceResult Add (DepartmentDTO dto)
        {
            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                result.Success = false;
                result.Message = "Tên Phòng ban không được để trống!";
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Code))
            {
                result.Success = false;
                result.Message = "Mã Phòng ban không được để trống!";
                return result;
            }
            
            bool exists = myDBContext.Departments
                .Any(d => d.Name.ToLower() == dto.Name.ToLower());

            if (exists)
            {
                result.Success = false;
                result.Message = "Tên Phòng ban đã tồn tại trong hệ thống!";
                return result;
            }

            exists = myDBContext.Departments
                .Any(d => d.Code.ToLower() == dto.Code.ToLower());

            if(exists)
            {
                result.Success = false;
                result.Message = "Mã Phòng ban đã tồn tại trong hệ thống!";
                return result;
            }

            var department = new Department
            {
                Name = dto.Name,
                Code = dto.Code,
                IsActive = dto.IsActive,
            };
            myDBContext.Departments.Add(department);
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Thêm Phòng ban thành công!";
            return result;
        }

        public ServiceResult Update(DepartmentDTO dto)
        {
            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                result.Success = false;
                result.Message = "Tên Phòng ban không được để trống!";
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Code))
            {
                result.Success = false;
                result.Message = "Mã Phòng ban không được để trống!";
                return result;
            }

            bool exists = myDBContext.Departments
                .Where(d => d.Id !=  dto.Id)
                .Any(d => d.Name.ToLower() == dto.Name.ToLower());

            if (exists)
            {
                result.Success = false;
                result.Message = "Tên Phòng ban đã tồn tại trong hệ thống!";
                return result;
            }

            exists = myDBContext.Departments
                .Where(d => d.Id != dto.Id)
                .Any(d => d.Code.ToLower() == dto.Code.ToLower());

            if (exists)
            {
                result.Success = false;
                result.Message = "Mã Phòng ban đã tồn tại trong hệ thống!";
                return result;
            }

            var department = myDBContext.Departments
                .SingleOrDefault(d => d.Id == dto.Id);

            if (department == null) {
                result.Success = false;
                result.Message = "Không tồn tại Phòng ban cần cập nhật!";
                return result;
            }

            department.Name = dto.Name;
            department.Code = dto.Code;
            department.IsActive = dto.IsActive;
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Cập nhật Phòng ban thành công!";
            return result;
        }

        public ServiceResult Delete(int id)
        {
            var result = new ServiceResult();

            var department = myDBContext.Departments
                .SingleOrDefault(d => d.Id == id);

            if (department == null)
            {
                result.Success = false;
                result.Message = "Không tồn tại Phòng ban cần xoá!";
                return result;
            }

            myDBContext.Departments.Remove(department);
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Xoá Phòng ban thành công!";
            return result;

        }

    }
}
