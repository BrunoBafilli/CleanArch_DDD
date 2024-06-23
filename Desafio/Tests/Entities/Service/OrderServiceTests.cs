using Domain.ArchPatterns.UnitOfWork;
using Domain.DomainEvents.Interfaces;
using Domain.DomainEvents.Order.Handlers;
using Domain.Entities.Order;
using Domain.Events.Order.Events;
using Infrastructure.IOC.ContainerDI;
using FluentAssertions;

namespace Tests.Entities.Service
{
    public class OrderServiceTests
    {
        private IUnitOfWork _unitOfWork;

        public OrderServiceTests()
        {
            _unitOfWork = DI.GetService<IUnitOfWork>();
        }
    }
}
