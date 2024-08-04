using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Persistence;
using MediatR;

namespace ChatWave.Application.Features.Queries.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserListDto>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserListDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetUsersAsync(request.Filters);
            return response.ResponseValue;
        }
    }
}
