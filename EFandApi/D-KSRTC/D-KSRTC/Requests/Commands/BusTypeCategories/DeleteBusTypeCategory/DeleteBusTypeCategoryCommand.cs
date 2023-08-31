using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypeCategories.DeleteBusTypeCategory
{
    public class DeleteBusTypeCategoryCommand : IRequest<int>
    {
        public int TCId { get; set; }
    }
}
