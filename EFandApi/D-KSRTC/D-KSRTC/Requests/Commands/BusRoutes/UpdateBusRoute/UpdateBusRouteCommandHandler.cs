﻿using D_KSRTC.Models;
using D_KSRTC.Repositories.BusRoutes;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace D_KSRTC.Requests.Commands.BusRoutes.UpdateBusRoute
{
    public class UpdateBusRouteCommandHandler : IRequestHandler<UpdateBusRouteCommand, int>
    {
        private readonly IBusRoutesRepository _busRouteRepository;

        public UpdateBusRouteCommandHandler(IBusRoutesRepository busRouteRepository)
        {
            _busRouteRepository = busRouteRepository;
        }

        public async Task<int> Handle(UpdateBusRouteCommand command, CancellationToken cancellationToken)
        {
            var busRoute = new BusRoute
            {
                BusRouteId = command.BusRouteId,
                BusId = command.BusId,
                RouteId = command.RouteId,
                TimeId = command.TimeId
            };

            return await _busRouteRepository.UpdateBusRouteAsync(busRoute);
        }
    }
}





