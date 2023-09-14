using D_KSRTC.Data;
using D_KSRTC.Models;
using D_KSRTC.Repositories.Bookings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Requests.Queries.Bookings.GetBookingById
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Booking>
    {
        private readonly IBookingRepository _bookingRepository;
    


        public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
          
        }

        public async Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(request.BookingId);

            return booking ?? new Booking();
        }
    }
}



/*from p in Product
join c in Catalog on c.Id equals p.CatalogId
join m in Manufacturer on m.Id equals p.ManufacturerId
where p.Active == 1
select new { Name = p.Name, CatalogId = p.CatalogId, ManufacturerId = p.ManufacturerId, CatalogName = c.Name, ManufacturerName = m.Name };*/