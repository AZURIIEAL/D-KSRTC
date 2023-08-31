using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
