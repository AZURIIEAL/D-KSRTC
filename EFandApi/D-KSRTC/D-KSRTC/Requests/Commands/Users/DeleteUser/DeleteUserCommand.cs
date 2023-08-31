using MediatR;

namespace D_KSRTC.Requests.Commands.Users.DeleteUser
{
    public class DeleteUserCommand :IRequest<int>
    {
        public int Id { get; set; }
    }
}
