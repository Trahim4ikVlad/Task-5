using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository
    {
        void Add(Client client);
        void Add(Manager manager);
        void Add(Order order);

        void Remove(Client client);
        void Remove(Manager manager);
        void Remove(Order order);

        void Update(Client client);
        void Update(Manager manager);
        void Update(Order order);

        IList<Client> GetClients();
        IList<Manager> GetManagers();
        IEnumerable<Order> GetOrders();
        IList<Client> GetClients(Func<Client, bool> where);
        IList<Manager> GetManagers(Func<Manager, bool> where);
        IEnumerable<Order> GetOrders(Func<Order, bool> where);

        Client GetClient(Func<Client, bool> @where);
        Manager GetManager(Func<Manager, bool> where);
        Order GetOrder(Func<Order, bool> where);
    }
}
