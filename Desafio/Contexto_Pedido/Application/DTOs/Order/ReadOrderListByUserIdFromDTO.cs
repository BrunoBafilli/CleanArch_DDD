using Domain.Entities.Order.ValueObject;
using Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntity = Domain.Entities.Order.Order;

namespace Application.DTOs.Order
{
    public class ReadOrderListByUserIdFromDTO
    {
        public static List<ReadOrderDTO> Map(ICollection<OrderEntity> orders)
        {
            var orderDtos = new List<ReadOrderDTO>();

            foreach (var order in orders)
            {
                var orderDto = new ReadOrderDTO
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderItems.Select(orderItem => new OrderItemDTO
                    {
                        Quantity = orderItem.Quantity,
                        Price = new PriceDTO
                        {
                            Value = orderItem.Price.Value
                        },
                        OrderItemProducts = orderItem.OrderItemProducts.Select(product => new OrderItemProductDTO
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            Price = new Price(product.Price.Value)
                        }).ToList()
                    }).ToList()
                };

                orderDtos.Add(orderDto);
            }

            return orderDtos;
        }
    }
}
