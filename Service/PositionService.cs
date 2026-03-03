using Data;
using Data.Emtity;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PositionService
    {
        private readonly MyDBContext myDBContext;

        public PositionService(MyDBContext dbContext)
        {
            this.myDBContext = dbContext;
        }

        public List<PositionDTO> GetAll()
        {
            return myDBContext.Positions
                .OrderBy(p => p.CreatedAt)
                .Select(p => new PositionDTO
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .ToList();
        }

        public List<PositionDTO> Search(string query)
        {
            string queryLower = query.ToLower();
            return myDBContext.Positions
                .Where(d => d.Name.ToLower().Contains(queryLower) ||
                            d.Code.ToLower().Contains(queryLower))
                .OrderBy(d => d.CreatedAt)
                .Select(d => new PositionDTO
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
        public PositionDTO? GetById(int id)
        {
            return myDBContext.Positions
                .Where(p => p.Id == id)
                .Select(p => new PositionDTO
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                })
                .FirstOrDefault();
        }

        public ServiceResult Add(PositionDTO dto)
        {
            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                result.Success = false;
                result.Message = "Tên Chức danh không được để trống!";
                return result;
            }
            if (string.IsNullOrWhiteSpace(dto.Code))
            {
                result.Success = false;
                result.Message = "Mã Chức danh không được để trống!";
                return result;
            }

            bool exists = myDBContext.Positions
                .Any(p => p.Name.ToLower() == dto.Name.ToLower());
            if (exists)
            {
                result.Success = false;
                result.Message = "Tên Chức danh đã tồn tại trong hệ thống!";
                return result;
            }

            exists = myDBContext.Positions
                .Any(p => p.Code.ToLower() == dto.Code.ToLower());
            if (exists)
            {
                result.Success = false;
                result.Message = "Mã Chức danh đã tồn tại trong hệ thống!";
                return result;
            }

            var position = new Position
            {
                Name = dto.Name,
                Code = dto.Code,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = default
            };

            myDBContext.Positions.Add(position);
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Thêm Chức danh thành công!";
            return result;
        }

        public ServiceResult Update(PositionDTO dto)
        {
            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                result.Success = false;
                result.Message = "Tên Chức danh không được để trống!";
                return result;
            }
            if (string.IsNullOrWhiteSpace(dto.Code))
            {
                result.Success = false;
                result.Message = "Mã Chức danh không được để trống!";
                return result;
            }

            bool exists = myDBContext.Positions
                .Where(p => p.Id != dto.Id)
                .Any(p => p.Name.ToLower() == dto.Name.ToLower());
            if (exists)
            {
                result.Success = false;
                result.Message = "Tên Chức danh đã tồn tại trong hệ thống!";
                return result;
            }

            exists = myDBContext.Positions
                .Where(p => p.Id != dto.Id)
                .Any(p => p.Code.ToLower() == dto.Code.ToLower());
            if (exists)
            {
                result.Success = false;
                result.Message = "Mã Chức danh đã tồn tại trong hệ thống!";
                return result;
            }

            var position = myDBContext.Positions
                .SingleOrDefault(p => p.Id == dto.Id);

            if (position == null)
            {
                result.Success = false;
                result.Message = "Không tồn tại Chức danh cần cập nhật!";
                return result;
            }

            position.Name = dto.Name;
            position.Code = dto.Code;
            position.IsActive = dto.IsActive;
            position.UpdatedAt = DateTime.Now;
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Cập nhật Chức danh thành công!";
            return result;
        }

        public ServiceResult Delete(int id)
        {
            var result = new ServiceResult();

            var position = myDBContext.Positions
                .SingleOrDefault(p => p.Id == id);

            if (position == null)
            {
                result.Success = false;
                result.Message = "Không tồn tại Chức danh cần xoá!";
                return result;
            }

            myDBContext.Positions.Remove(position);
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Xoá Chức danh thành công!";
            return result;
        }
    }
}
