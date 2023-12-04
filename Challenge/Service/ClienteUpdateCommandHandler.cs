using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ClienteUpdateCommandHandler
    {
        
        public ClienteUpdateCommandHandler(int id, string nombres, string apellidos, string cUIT, string telefono, string email)
        {
            this.Id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.cUIT = cUIT;
            this.telefono = telefono;
            this.email = email;
        }

        private readonly int Id;
        private string nombres;
        private string apellidos;
        private string cUIT;
        private string telefono;
        private string email;

        public Task<Cliente> Handle()
        {
            throw new System.NotImplementedException();
        }
    }
}
