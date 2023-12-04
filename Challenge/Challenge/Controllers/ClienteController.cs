using Challenge.Dtos;
using Domain.Models;
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
        private readonly Domain.Models.ApplicationDbContext _context;
        
        public ClienteController(ILogger<ClienteController> logger, Domain.Models.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet("all")]
        public async Task<List<ClienteDto>> GetAsync()
        {
            var queryHandler = new ClienteAllQueryHandler();

            //var resp = await queryHandler.Handle();

            var resp = _context.Clientes.ToList();

            return resp.Select(x => new ClienteDto
            {
                ID = x.ID,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                FechaDeNacimiento = x.Fecha_De_Nacimiento,
                CUIT = x.CUIT,
                Domicilio = x.Domicilio,
                Telefono = x.Telefono_celular,
                Email = x.Email
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ClienteDto> GetByIdAsync(int id)
        {
            var resp = _context.Clientes.SingleOrDefault(cliente => cliente.ID == id);

            ClienteDto clienteDto = new();

            if (resp == null) throw new Exception($"El cliente con id {id} no se encuentra registrado en nuestro sistema");
            
            clienteDto.ID = resp.ID;
            clienteDto.Nombres = resp.Nombres;
            clienteDto.Apellidos = resp.Apellidos;
            clienteDto.FechaDeNacimiento = resp.Fecha_De_Nacimiento;
            clienteDto.CUIT = resp.CUIT;
            clienteDto.Domicilio = resp.Domicilio;
            clienteDto.Telefono = resp.Telefono_celular;
            clienteDto.Email = resp.Email;

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

                var clienteModel = new ClienteModel
                {
                    ID = 2,
                    Nombres = clienteDto.Nombres,
                    Apellidos = clienteDto.Apellidos,
                    CUIT = clienteDto.CUIT,
                    Telefono_celular = clienteDto.Telefono,
                    Email = clienteDto.Email
                };


                _context.Clientes.Add(clienteModel);

                _context.SaveChanges();


                result = Ok();
            }

            return result;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] ClienteDto clienteDto)
        {
            IActionResult result;
            if (clienteDto == null) result = BadRequest();

            var cliente2Update = _context.Clientes.SingleOrDefault(cliente => cliente.ID == clienteDto.ID);

            if (string.IsNullOrEmpty(clienteDto.Nombres) ||
                string.IsNullOrEmpty(clienteDto.Apellidos) ||
                string.IsNullOrEmpty(clienteDto.CUIT) ||
                string.IsNullOrEmpty(clienteDto.Telefono) ||
                string.IsNullOrEmpty(clienteDto.Email) ||
                cliente2Update == null)
                result = BadRequest();
            else
            {
                cliente2Update.Nombres = clienteDto.Nombres;
                cliente2Update.Apellidos = clienteDto.Apellidos;
                cliente2Update.CUIT = clienteDto.CUIT;
                cliente2Update.Telefono_celular = clienteDto.Telefono;
                cliente2Update.Email = clienteDto.Email;

                _context.Update(cliente2Update);
                _context.SaveChanges();

                result = Ok();
            }

            return result;
        }
    }
}
