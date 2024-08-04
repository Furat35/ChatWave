using ChatWave.Application.Dtos.Users;
using MediatR;

namespace ChatWave.Application.Features.Queries.Users
{
    public class GetUserByIdQuery : IRequest<UserListDto>
    {
        public GetUserByIdQuery()
        {

        }

        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
