using D_KSRTC.Models;
using D_KSRTC.Repositories.Times;
using MediatR;

namespace D_KSRTC.Requests.Queries.Times.GetAllTimes
{
    public class GetAllTimesQueryHandler : IRequestHandler<GetAllTimesQuery, List<Time>>
    {
        private readonly ITimeRepository _timeRepository;

        public GetAllTimesQueryHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<List<Time>> Handle(GetAllTimesQuery query, CancellationToken cancellationToken)
        {
            return await _timeRepository.GetAllTimesAsync();
        }
    }
}
