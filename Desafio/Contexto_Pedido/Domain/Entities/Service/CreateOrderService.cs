using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArchPatterns.Repositories;
using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Order;
using Domain.Validations;

namespace Domain
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrder(int clientId, OrderItem orderItem, Product product)
        {
            Order order = OrderFactory.FactoryOrderAsync(clientId, orderItem, product);

            await _unitOfWork.OrderRepository.CreateAsync(order);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateOrder(int clientId, Order order)
        {
            Order findedOrder = await _unitOfWork.OrderRepository.ReadOrdersByUserId(clientId, order.Id);

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));
            ValidationDefaultException.IsNullOrEmpty(order, nameof(order));

            await _unitOfWork.OrderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();
        }
    }
}
