using AutoMapper;
using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Exceptions;
using ChatWave.Application.Filters;
using ChatWave.Application.Helpers;
using ChatWave.Application.Persistence;
using ChatWave.Application.Persistence.Repository;
using ChatWave.Application.UnitOfWorks;
using ChatWave.Domain.Entities;
using System.Linq.Expressions;
using System.Text;

namespace ChatWave.Infrastructure.Persistence
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userService;
        private readonly IMapper _mapper;
        private readonly IUserFilterService _userFilterService;
        private readonly IHeaderService _headerService;
        private readonly IPasswordGenerationService _passwordGenerationService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IUserFilterService userFilterService, IHeaderService headerService, IPasswordGenerationService passwordGenerationService)
        {
            _userService = unitOfWork.GetRepository<User>();
            _mapper = mapper;
            _userFilterService = userFilterService;
            _headerService = headerService;
            _passwordGenerationService = passwordGenerationService;
        }

        public IBaseRepository<User> Users { get => _userService; }

        public async Task<UserResponse<List<UserListDto>>> GetUsersAsync(UserRequestFilter filters = null, Expression<Func<User, bool>> predicate = null,
            List<Expression<Func<User, object>>> includes = null, bool isTracking = false)
        {
            var users = await _userService.GetAllAsync(predicate, includes, isTracking);
            var filteredUsers = _userFilterService.FilterUsers(filters, users);
            _headerService.AddToResponseHeaders(filteredUsers.Headers);

            return _mapper.Map<UserResponse<List<UserListDto>>>(filteredUsers);
        }

        public async Task<UserListDto> GetUserByIdAsync(string id, List<Expression<Func<User, object>>> includes = null, bool isTracking = true)
        {
            var user = await _userService.GetByIdAsync(Guid.Parse(id), includes, isTracking) ?? throw new NotFoundException($"User with id : {id} is not found!");
            return _mapper.Map<UserListDto>(user);
        }

        public async Task<string> CreateUserAsync(UserCreateDto model)
        {
            var user = _mapper.Map<User>(model);
            var generatePassword = GeneratePasswordHash(model.Password);
            user.HashedPassword = generatePassword.storedHashedPassword;
            user.PasswordSalt = generatePassword.storedSalt;
            int affectedRows = await _userService.AddAsync(user);

            return affectedRows > 0
                ? user.Id.ToString()
                : string.Empty;
        }

        public async Task<bool> UpdateUser(UserUpdateDto model)
        {
            var user = await _userService.GetByIdAsync(Guid.Parse(model.Id)) ?? throw new NotFoundException($"User with id : {model.Id} is not found!");
            _mapper.Map(model, user);
            int affectedRows = await _userService.AddAsync(user);

            return affectedRows > 0;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userService.GetByIdAsync(Guid.Parse(id)) ?? throw new NotFoundException($"User with id : {id} is not found!");
            int affectedRows = await _userService.DeleteAsync(user);

            return affectedRows > 0;
        }

        private (string storedSalt, string storedHashedPassword) GeneratePasswordHash(string password)
        {
            var salt = _passwordGenerationService.GenerateSalt();
            var combinedBytes = _passwordGenerationService.Combine(Encoding.UTF8.GetBytes(password), salt);
            var hashedBytes = _passwordGenerationService.HashBytes(combinedBytes);
            string storedSalt = Convert.ToBase64String(salt);
            string storedHashedPassword = Convert.ToBase64String(hashedBytes);

            return (storedSalt, storedHashedPassword);
        }
    }
}
