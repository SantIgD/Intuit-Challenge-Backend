using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ClienteModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }
        public DateTime Fecha_De_Nacimiento { get; set; }
        [Required]
        [MaxLength(50)]
        public string CUIT { get; set; }
        public string Domicilio { get; set; }
        [Required]
        [MaxLength(50)]
        public string Telefono_celular { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
