using Domain.ArchPatterns.UnitOfWork;
using Domain.Validations;

namespace Domain.Entities.Service
{
    public class OrderService : ICreateOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrder(int clientId, Order.Order order)
        {
            await _unitOfWork.OrderRepository.CreateAsync(order);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateOrder(int clientId, Order.Order order)
        {
            Order.Order findedOrder = await _unitOfWork.OrderRepository.ReadOrdersByUserId(clientId, order.Id);

            ValidationDefaultException.IsNullOrEmpty(findedOrder, nameof(findedOrder));
            ValidationDefaultException.IsNullOrEmpty(order, nameof(order));

            await _unitOfWork.OrderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();
        }
    }
}
