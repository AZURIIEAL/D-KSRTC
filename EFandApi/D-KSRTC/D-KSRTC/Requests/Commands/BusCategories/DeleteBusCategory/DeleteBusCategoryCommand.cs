using MediatR;

namespace D_KSRTC.Requests.Commands.BusCategories.DeleteBusCategory
{
    public class DeleteBusCategoryCommand : IRequest<int>
    {
        public int CategoryId { get; set; }
    }
}
