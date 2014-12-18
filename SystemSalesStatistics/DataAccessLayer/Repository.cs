using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class Repository:IRepository
    {
        private readonly ClientRepository _clientRepository;
        private readonly ManagerRepository _managerRepository;
        private readonly OrderRepository _orderRepository;

        public Repository()
        {
            _clientRepository = new ClientRepository();
            _managerRepository = new ManagerRepository();
            _orderRepository = new OrderRepository();
        }

        public void Add(Client client)
        {
            _clientRepository.Add(client);
        }

        public void Add(Manager manager)
        {
            _managerRepository.Add(manager);
        }

        public void Add(Order order)
        {
            _orderRepository.Add(order);
        }

        public void Remove(Client client)
        {
            _clientRepository.Remove(client);
        }

        public void Remove(Manager manager)
        {
            _managerRepository.Remove(manager);
        }

        public void Remove(Order order)
        {
            _orderRepository.Remove(order);
        }

        public void Update(Client client)
        {
           _clientRepository.Update(client);
        }

        public void Update(Manager manager)
        {
            _managerRepository.Update(manager);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public IList<Client> GetClients()
        {
            return _clientRepository.GetAll();
        }

        public IList<Manager> GetManagers()
        {
            return _managerRepository.GetAll();
        }

        public IList<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public IList<Client> GetClients(Func<Client, bool> where)
        {
            return _clientRepository.GetList(where);
        }

        public IList<Manager> GetManagers(Func<Manager, bool> where)
        {
            return _managerRepository.GetList(where);
        }

        public IList<Order> GetOrders(Func<Order, bool> where)
        {
            return _orderRepository.GetList(where);
        }

        public Client GetClient(Func<Client, bool> @where)
        {
            return  _clientRepository.GetSingle(where);
        }

        public Manager GetManager(Func<Manager, bool> where)
        {
            return _managerRepository.GetSingle(where);
        }

        public Order GetOrder(Func<Order, bool> where)
        {
            return _orderRepository.GetSingle(where);
        }
    }
}
