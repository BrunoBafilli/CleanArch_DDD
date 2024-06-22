using Domain.Entities.Interfaces;
using Domain.Entities.Order.GOFPatterns;
using Domain.Events.Interfaces;
using Domain.Events.Order.Events;
using Domain.Validations;

namespace Domain.Entities.Order
{
    public sealed class Order : EntityDefault<int>, IAgregateRoot<int>
    {
        //Events
        private readonly List<IEventDomain> _events = new List<IEventDomain>();
        public ICollection<IEventDomain> CompletedOrderEvents => _events.AsReadOnly();

        //Props
        public DateTime OrderDate { get; private set; }
        private List<OrderItem> _orderItems;
        public IReadOnlyList<OrderItem> OrderItems => _orderItems;

        //Relacionamento
        public int ClientId { get; private set; }

        //Construtores
        public Order(int clientId)
        {
            ClientId = clientId;
            OrderDate = DateTime.Now;
            _orderItems = new List<OrderItem>();
        }

        //Methods
        public void AddOrderItem()
        {
            OrderItem order = new OrderBuilder()
                .Builder();

            _orderItems.Add(order);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            var findedItem = OrderItems.FirstOrDefault(x => x == orderItem);

            ValidationDefaultException.IsNullOrEmpty(findedItem, nameof(findedItem));

            _orderItems.Remove(orderItem);
        }


        //Events
        public void PlaceOrder()
        {
            CompletedOrderEvent completedOrderEvent = new CompletedOrderEvent();
            AddEvent(completedOrderEvent);
        }

        private void AddEvent(CompletedOrderEvent completedOrderEvent)
        {
            _events.Add(completedOrderEvent);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }


        /////
        //public void DispatchEvent()
        //{
        //    HandlersConfig().Dispatcher(_events);
        //}

        //public void ClearDomainEvents()
        //{
        //    _events.Clear();
        //}

        //public CompletedOrderEventDispatcher HandlersConfig()
        //{
        //    CompletedOrderEvent completedOrderEvent = new CompletedOrderEvent();
        //    _events.Add(completedOrderEvent);

        //    var handlers = new List<IEventHandler<CompletedOrderEvent>>()
        //    {
        //        new CompletedOrderHandler()
        //    };

        //    return new CompletedOrderEventDispatcher(handlers);
        //}
    }
}
