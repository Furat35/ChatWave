using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Filters;
using ChatWave.Application.Persistence.Repository;
using ChatWave.Domain.Entities;
using System.Linq.Expressions;

namespace ChatWave.Application.Persistence
{
    public interface IUserService
    {
        IBaseRepository<User> Users { get; }
        Task<UserResponse<List<UserListDto>>> GetUsersAsync(UserRequestFilter filters = null, Expression<Func<User, bool>> predicate = null, List<Expression<Func<User, object>>> includes = null, bool isTracking = false);
        Task<UserListDto> GetUserByIdAsync(string id, List<Expression<Func<User, object>>> includes = null, bool isTracking = true);
        Task<string> CreateUserAsync(UserCreateDto model);
        Task<bool> UpdateUser(UserUpdateDto model);
        Task<bool> DeleteUser(string id);
    }
}
