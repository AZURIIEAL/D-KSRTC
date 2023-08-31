using MediatR;

namespace D_KSRTC.Requests.Commands.BusCategories.UpdateBusCategory
{
    public class UpdateBusCategoryCommand : IRequest<int>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public float BaseFare { get; set; }
    }
}
