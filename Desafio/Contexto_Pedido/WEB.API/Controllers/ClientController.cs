using Application.DTOs.Client;
using Application.Service.Client;
using Application.Service.Client.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEB.API.Controllers.Client
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClienteServiceApplication _clienteServiceApplication;

        public ClientController(IClienteServiceApplication clienteServiceApplication)
        {
            _clienteServiceApplication = clienteServiceApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNewClientDTO createNewClientDTO)
        {
            try
            {
                await _clienteServiceApplication.CreateNewClientAsync(createNewClientDTO);
                return Ok("Cliente criado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao criar cliente: ${e.Message}");
            }
        }

        [HttpGet("{clientId}")] // Usando parâmetro na rota
        public async Task<IActionResult> Read(int userId)
        {
            try
            {
                var usuarioEncontrado = await _clienteServiceApplication.ReadClientByIdAsync(userId);

                return Ok(usuarioEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao ler usuário: {ex.Message}");
            }
        }
    }
}
