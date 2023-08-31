using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusCategories.AddBusCategory
{
    public class AddBusCategoryCommand : IRequest<BusCategory>
    {
        public string CategoryName { get; set; } = string.Empty;
        public float BaseFare { get; set; }

        public AddBusCategoryCommand(string categoryName, float baseFare)
        {
            CategoryName = categoryName;
            BaseFare = baseFare;
        }
    }
}
