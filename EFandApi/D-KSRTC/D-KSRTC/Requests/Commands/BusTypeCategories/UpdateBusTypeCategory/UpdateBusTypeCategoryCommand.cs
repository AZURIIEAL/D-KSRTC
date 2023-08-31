using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypeCategories.UpdateBusTypeCategory
{
        public class UpdateBusTypeCategoryCommand : IRequest<int>
        {
            public int TCId { get; set; }
            public int CategoryId { get; set; }
            public int TypeId { get; set; }
        }
}
