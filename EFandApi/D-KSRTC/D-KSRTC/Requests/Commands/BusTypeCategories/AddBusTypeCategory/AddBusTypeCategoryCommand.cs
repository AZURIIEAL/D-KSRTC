using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypeCategories.AddBusTypeCategory
{
    public class AddBusTypeCategoryCommand : IRequest<BusTypeCategory>
    {
        public int CategoryId { get; set; }
        public int TypeId { get; set; }

        public AddBusTypeCategoryCommand(int categoryId, int typeId)
        {
            CategoryId = categoryId;
            TypeId = typeId;
        }
    }
}
