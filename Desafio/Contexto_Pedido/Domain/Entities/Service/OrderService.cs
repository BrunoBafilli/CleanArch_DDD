using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Client;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Entities.Service.GOFPatterns;
using Domain.Validations;

namespace Domain
{
    public class OrderService : ICreateOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateNewOrder(int quantity, int clientId, Product product)
        {
            Order newOrder = OrderServiceFactory.createOrderService(quantity, clientId, product);

            await _unitOfWork.OrderRepository.CreateAsync(newOrder);

            await _unitOfWork.CommitAsync();
        }


        //public async Task CreateNewOrder(int orderItemId, int clientId, Product product)
        //{
        //    ValidationDefaultException.NumberLessThanZero(clientId, nameof(clientId));
        //    ValidationDefaultException.IsNullOrEmpty(product, nameof(product));

        //    Order order = new Order(clientId);
        //    await _unitOfWork.OrderRepository.CreateAsync(order);

        //    OrderItem orderItem = order.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        //    ValidationDefaultException.IsNullOrEmpty(orderItem, nameof(orderItem));

        //    orderItem.AddProduct(product.Name, product.Description, product.Price.Value, product.Stock.Quantity);

        //    await _unitOfWork.OrderRepository.UpdateAsync(findedOrder);

        //    await _unitOfWork.CommitAsync();
        //}
    }
}
