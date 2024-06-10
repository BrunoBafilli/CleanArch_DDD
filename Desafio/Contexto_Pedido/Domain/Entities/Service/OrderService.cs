using Domain.ArchPatterns.UnitOfWork;
using Domain.Entities.Client;
using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using Domain.Entities.Product;
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

        public async Task CreateNewOrder(int clientId, List<int> productsId)
        {
            Order newOrder = await OrderServiceOneItemFactory.createOrderService(clientId, productsId, _unitOfWork);

            await _unitOfWork.OrderRepository.CreateAsync(newOrder);

            await _unitOfWork.CommitAsync();
        }
    }
}
