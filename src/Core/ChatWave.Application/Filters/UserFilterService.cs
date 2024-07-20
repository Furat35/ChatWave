using AutoMapper;
using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Helpers;
using ChatWave.Domain.Entities;

namespace ChatWave.Application.Filters
{
    public class UserFilterService : IUserFilterService
    {
        private readonly IMapper _mapper;

        public UserFilterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserResponse<List<UserListDto>> FilterUsers(UserRequestFilter filters, IQueryable<User> users)
        {
            int pageNumber = users.Count() % filters.PageSize == 0 ? users.Count() / filters.PageSize : users.Count() / filters.PageSize + 1;
            Metadata metadata = new(filters.Page, filters.PageSize, users.Count(), pageNumber);
            users = AddPagination(filters, users);
            var header = new CustomHeaders().AddPaginationHeader(metadata);
            var mappedUsers = _mapper.Map<List<UserListDto>>(users);

            return new()
            {
                ResponseValue = mappedUsers,
                Headers = header
            };
        }

        private IQueryable<User> AddPagination(UserRequestFilter filters, IQueryable<User> users)
          => users
              .OrderBy(_ => _.Username)
              .Skip((filters.Page - 1) * filters.PageSize)
              .Take(filters.PageSize);
    }

    public interface IUserFilterService
    {
        public UserResponse<List<UserListDto>> FilterUsers(UserRequestFilter filters, IQueryable<User> users);
    }

}
