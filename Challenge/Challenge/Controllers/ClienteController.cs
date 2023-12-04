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
    }
}
