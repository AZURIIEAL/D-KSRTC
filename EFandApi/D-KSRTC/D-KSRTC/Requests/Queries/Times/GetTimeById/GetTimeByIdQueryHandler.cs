using D_KSRTC.Models;
using D_KSRTC.Repositories.Times;
using MediatR;

namespace D_KSRTC.Requests.Queries.Times.GetTimeById
{
    public class GetTimeByIdQueryHandler : IRequestHandler<GetTimeByIdQuery, Time>
    {
        private readonly ITimeRepository _timeRepository;

        public GetTimeByIdQueryHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<Time> Handle(GetTimeByIdQuery query, CancellationToken cancellationToken)
        {
            var res = await _timeRepository.GetTimeByIdAsync(query.TimeId);
            return res ?? new Time();
        }
    }
}
