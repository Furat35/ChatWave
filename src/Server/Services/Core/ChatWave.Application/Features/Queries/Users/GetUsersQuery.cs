using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Filters;
using MediatR;

namespace ChatWave.Application.Features.Queries.Users
{
    public class GetUsersQuery : IRequest<List<UserListDto>>
    {
        public GetUsersQuery()
        {

        }

        public GetUsersQuery(UserRequestFilter filters)
        {
            Filters = filters;
        }

        public UserRequestFilter Filters { get; set; }
    }
}
