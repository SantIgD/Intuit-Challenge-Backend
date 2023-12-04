using Challenge.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<List<ClienteDto>> GetAsync()
        {
            var queryHandler = new ClienteAllQueryHandler();

            var resp = await queryHandler.Handle();

            return resp.Select(x => new ClienteDto
            {
                ID = x.ID,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                FechaDeNacimiento = x.FechaDeNacimiento,
                CUIT = x.CUIT,
                Domicilio = x.Domicilio,
                Telefono = x.Telefono,
                Email = x.Email
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ClienteDto> GetByIdAsync(int id)
        {
            var queryHandler = new ClienteByIdQueryHandler(id);

            var cliente = await queryHandler.Handle();

            var clienteDto = new ClienteDto();

            if (cliente != null)
            {
                clienteDto.ID = cliente.ID;
                clienteDto.Nombres = cliente.Nombres;
                clienteDto.Apellidos = cliente.Apellidos;
                clienteDto.FechaDeNacimiento = cliente.FechaDeNacimiento;
                clienteDto.CUIT = cliente.CUIT;
                clienteDto.Domicilio = cliente.Domicilio;
                clienteDto.Telefono = cliente.Telefono;
                clienteDto.Email = cliente.Email;
            }

            return clienteDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClienteDto clienteDto)
        {
            IActionResult result;
            if (clienteDto == null) result = BadRequest();


            if (string.IsNullOrEmpty(clienteDto.Nombres) ||
                string.IsNullOrEmpty(clienteDto.Apellidos) ||
                string.IsNullOrEmpty(clienteDto.CUIT) ||
                string.IsNullOrEmpty(clienteDto.Telefono) ||
                string.IsNullOrEmpty(clienteDto.Email))
                result = BadRequest();
            else
            {
                var commandHandler = new ClienteAddCommandHandler(clienteDto.Nombres,
                                                                  clienteDto.Apellidos,
                                                                  clienteDto.CUIT,
                                                                  clienteDto.Telefono,
                                                                  clienteDto.Email);
                await commandHandler.Handle();

                result = Ok();
            }

            return result;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] ClienteDto clienteDto)
        {
            IActionResult result;
            if (clienteDto == null) result = BadRequest();


            if (string.IsNullOrEmpty(clienteDto.Nombres) ||
                string.IsNullOrEmpty(clienteDto.Apellidos) ||
                string.IsNullOrEmpty(clienteDto.CUIT) ||
                string.IsNullOrEmpty(clienteDto.Telefono) ||
                string.IsNullOrEmpty(clienteDto.Email))
                result = BadRequest();
            else
            {
                var commandHandler = new ClienteUpdateCommandHandler(clienteDto.ID,
                                                                     clienteDto.Nombres,
                                                                     clienteDto.Apellidos,
                                                                     clienteDto.CUIT,
                                                                     clienteDto.Telefono,
                                                                     clienteDto.Email);
                await commandHandler.Handle();

                result = Ok();
            }

            return result;
        }
    }
}
