using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Dtos
{
    public class ClienteDto
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }   
        public DateTime FechaDeNacimiento { get; set; }
        public string CUIT { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
