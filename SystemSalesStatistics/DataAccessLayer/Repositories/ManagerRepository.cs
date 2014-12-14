using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ManagerRepository : GenericDataRepository<Manager>, IManagerRepository
    {
    }
    public interface IManagerRepository : IGenericDataRepository<Manager>
    {
    }
}
