using Domain.Entities.Order;
using Domain.Entities.Order.ValueObject;
using System;
using System.Collections.Generic;

namespace Application.DTOs.Order
{
    public class ReadOrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }

    public class OrderItemDTO
    {
        public int Quantity { get; set; }
        public PriceDTO Price { get; set; }
        public List<OrderItemProductDTO> OrderItemProducts { get; set; } = new List<OrderItemProductDTO>();
    }

    public class OrderItemProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
    }

    public class PriceDTO
    {
        public decimal Value { get; set; }
    }
}