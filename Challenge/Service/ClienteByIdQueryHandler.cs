using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ClienteByIdQueryHandler
    {
        public ClienteByIdQueryHandler(int id)
        {
            Id = id;
        }

        private readonly int Id;

        public Task<Cliente> Handle()
        {
            throw new System.NotImplementedException();
        }
    }
}
