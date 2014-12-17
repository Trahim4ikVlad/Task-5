using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ClientRepository : GenericDataRepository<Client>, IClientRepository
    {
    }

    public interface IClientRepository : IGenericDataRepository<Client>
    {
    }
}
