using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Users.GetUserById
{
    public class GetUsersByIdQuery :IRequest<User>
    {
        public int Id { get; set; }
    }
}
