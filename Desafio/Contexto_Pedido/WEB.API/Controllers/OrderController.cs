using Application.DTOs.Client;
using Application.DTOs.Order;
using Application.Service.Client.Interfaces;
using Application.Service.Order.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WEB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAplication _orderServiceAplication;

        public OrderController(IOrderServiceAplication orderServiceAplication)
        {
            _orderServiceAplication = orderServiceAplication;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreteNewOrderDTO creatNewOrderDto)
        {
            try
            {
                await _orderServiceAplication.CreateNewOrderAsync(creatNewOrderDto);

                return Ok("Pedido criado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao criar pedido: ${e.Message}");
            }
        }

        [HttpGet("Read")]
        public async Task<IActionResult> Read([FromQuery] int orderId, [FromQuery] int clientId)
        {
            try
            {
                var order = await _orderServiceAplication.ReadOrderByorderIdClientIdAsync(orderId, clientId);

                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao ler pedido: ${e.Message}");
            }
        }


        [HttpGet("ReadOrders")]
        public async Task<IActionResult> Read([FromQuery] int clientId)
        {
            try
            {
                var orders = await _orderServiceAplication.ReadOrdersByClientIdAsync(clientId);
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                };
                return Ok(JsonSerializer.Serialize(orders, options));
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao ler pedido: {e.Message}");
            }
        }

    }
}
