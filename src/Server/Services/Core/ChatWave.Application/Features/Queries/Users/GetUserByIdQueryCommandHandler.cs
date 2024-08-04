using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Persistence;
using MediatR;

namespace ChatWave.Application.Features.Queries.Users
{
    public class GetUserByIdQueryCommandHandler : IRequestHandler<GetUserByIdQuery, UserListDto>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserListDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByIdAsync(request.Id);
        }
    }
}
