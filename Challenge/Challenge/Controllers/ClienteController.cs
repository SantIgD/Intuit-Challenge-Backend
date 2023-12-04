using Challenge.Dtos;
using Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ApplicationDbContext _context;
        
        public ClienteController(ILogger<ClienteController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet("getAll")]
        public List<ClienteDto> Get()
        {
            
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

        [HttpGet("getById/{id}")]
        public ClienteDto GetById(int id)
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

        [HttpGet("getByNames/{nombres}")]
        public List<ClienteDto> GetByName(string nombres)
        {

            var resp = _context.Clientes.Where(cliente => cliente.Nombres.Contains(nombres)).ToList();

            ClienteDto clienteDto = new();

            if (resp == null) throw new Exception($"El cliente con nombres {nombres} no se encuentra registrado en nuestro sistema");

            return resp.Select(cliente => new ClienteDto
            {
               ID = cliente.ID,
               Nombres = cliente.Nombres,
               Apellidos = cliente.Apellidos,
               FechaDeNacimiento = cliente.Fecha_De_Nacimiento,
               CUIT = cliente.CUIT,
               Domicilio = cliente.Domicilio,
               Telefono = cliente.Telefono_celular,
               Email = cliente.Email
             }).ToList();
        }

        [HttpPost("addCliente")]
        public IActionResult AddCliente([FromBody] ClienteDto clienteDto)
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

        [HttpPut("updateCliente")]
        public IActionResult UpdateCliente([FromBody] ClienteDto clienteDto)
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
