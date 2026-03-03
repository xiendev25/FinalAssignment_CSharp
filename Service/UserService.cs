
using Data;
using Data.Emtity;
using DTO;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class UserService
    {
        private readonly MyDBContext myDBContext;

        public UserService(MyDBContext dbContext)
        {
            myDBContext = dbContext;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        public List<UserDTO> GetAll()
        {
            return myDBContext.Users
                .OrderBy(u => u.CreatedAt)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToList();
        }

        public List<UserDTO> Search(string query)
        {
            string queryLower = query.ToLower();
            return myDBContext.Users
                .Where(u => u.Username.ToLower().Contains(queryLower))
                .OrderBy(u => u.CreatedAt)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToList();
        }

        public UserDTO? GetById(int id)
        {
            return myDBContext.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .FirstOrDefault();
        }

        public UserDTO? GetByUserName(string username)
        {
            return myDBContext.Users
                .Where(u => u.Username == username)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .FirstOrDefault();
        }

        public ServiceResult Add(UserDTO dto)
        {
            var result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(dto.Username))
            {
                result.Success = false;
                result.Message = "Tên đăng nhập không được để trống!";
                return result;
            }    

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                result.Success = false;
                result.Message = "Mật khẩu không được để trống!";
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Role))
            {
                result.Success = false;
                result.Message = "Vai trò không hợp lệ!";
                return result;
            }

            if (myDBContext.Users.Any(u => u.Username.ToLower() == dto.Username.ToLower()))
            {
                result.Success = false;
                result.Message = "Tên đăng nhập đã tồn tại trong hệ thống!";
                return result;
            }

            var user = new User
            {
                Username = dto.Username,
                Password = HashPassword(dto.Password),
                Role =  dto.Role,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = default
            };

            myDBContext.Users.Add(user);
            myDBContext.SaveChanges();

            result.Success = true;
            result.Message = "Thêm người dùng thành công!";
            return result;

        }

        public ServiceResult Update(UserDTO dto)
        {
            var result = new ServiceResult();

            var user = myDBContext.Users.SingleOrDefault(u => u.Id == dto.Id);
            if (user == null)
            {
                result.Success = false;
                result.Message = "Không tồn tại người dùng cần cập nhật!";
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Username))
            {
                result.Success = false;
                result.Message = "Tên đăng nhập không được để trống!";
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Role))
            {
                result.Success = false;
                result.Message = "Vai trò không hợp lệ!";
                return result;
            }

            bool exists = myDBContext.Users
                .Any(u => u.Id != dto.Id && u.Username.ToLower() == dto.Username.ToLower());
            if (exists)
            {
                result.Success = false;
                result.Message = "Tên đăng nhập đã tồn tại trong hệ thống!";
                return result;
            }

            string password = user.Password;

            if (!string.IsNullOrEmpty(dto.Password))
            {
                password = dto.Password;
            }    

            user.Username = dto.Username;
            user.Role = dto.Role;
            user.Password = HashPassword(password);
            user.IsActive = dto.IsActive;
            user.UpdatedAt = DateTime.Now;

            myDBContext.SaveChanges();
            result.Success = true;
            result.Message = "Cập nhật người dùng thành công!";
            return result;

        }

        public ServiceResult Delete(int id)
        {
            var result = new ServiceResult();
            var user = myDBContext.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                result.Success = false;
                result.Message = "Không tồn tại người dùng cần xoá!";
                return result;
            }

            myDBContext.Users.Remove(user);
            myDBContext.SaveChanges();
            result.Success = true;
            result.Message = "Xoá người dùng thành công!";
            return result;
        }

        public ServiceResult Login(string username, string password)
        {
            var result = new ServiceResult();

            if (string.IsNullOrEmpty(username))
            {
                result.Success = false;
                result.Message = "Vui lòng nhập tên người dùng!";
                return result;
            }

            if (string.IsNullOrEmpty(password))
            {
                result.Success = false;
                result.Message = "Vui lòng nhập mật khẩu!";
                return result;
            }

            var user = myDBContext.Users.SingleOrDefault(u => u.Username.ToLower() == username.ToLower());
            if (user == null)
            {
                result.Success = false;
                result.Message = "Tên đăng nhập không tồn tại!";
                return result;
            }    
       
            if (!user.IsActive)
            {
                result.Success = false;
                result.Message = "Tài khoản đã bị vô hiệu hoá!";
                return result;
            }

            if (HashPassword(password) != user.Password)
            {
                result.Success = false;
                result.Message = "Mật khẩu không khớp!";
                return result;
            }

            result.Success = true;
            result.Message = "Đăng nhập thành công!";
            return result;
        }

        public ServiceResult ChangePassword(string username, string currentPassword, string newPassword)
        {
            var result = new ServiceResult();

            if (string.IsNullOrEmpty(username))
            {
                result.Success = false;
                result.Message = "Vui lòng nhập tên người dùng!";
                return result;
            }

            if (string.IsNullOrEmpty(currentPassword))
            {
                result.Success = false;
                result.Message = "Vui lòng nhập mật khẩu cũ!";
                return result;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                result.Success = false;
                result.Message = "Vui lòng nhập mật khẩu mới!";
                return result;
            }

            var user = myDBContext.Users.SingleOrDefault(u => u.Username.ToLower() == username.ToLower());
            if (user == null)
            {
                result.Success = false;
                result.Message = "Tên người dùng không tồn tại!";
                return result;
            }


            if (HashPassword(currentPassword) != user.Password)
            {
                result.Success = false;
                result.Message = "Mật khẩu hiện tại không khớp!";
                return result;
            }

            user.Password = HashPassword(newPassword);
            user.UpdatedAt = DateTime.Now;

            myDBContext.SaveChanges();
            result.Success = true;
            result.Message = "Thay đổi mật khẩu thành công!";
            return result;
        }
    }
}
