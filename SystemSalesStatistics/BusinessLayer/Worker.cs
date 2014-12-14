using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace BusinessLayer
{
    public class Worker:IWorker
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IManagerRepository _managerRepository;

        public Worker()
        {
            _orderRepository = new OrderRepository();
            _clientRepository = new ClientRepository();
            _managerRepository = new ManagerRepository();
        }

        public Worker(IOrderRepository orderRepository, IClientRepository clientRepository, IManagerRepository managerRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _managerRepository = managerRepository;
        }

        public IList<OrderViewModel> GetAllOrders()
        {
            IList<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var order in _orderRepository.GetAll())
            {
                orderViewModels.Add(order.ToOrderViewModel());
            }
            return orderViewModels;
        }

        

        public IList<OrderViewModel> FilterBy(Func<Order, bool> @where)
        {
            throw new NotImplementedException();
        }

        public IList<OrderViewModel> FilterBy(params Expression<Func<Order, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Add(params OrderViewModel[] orderViewModels)
        {
            throw new NotImplementedException();
        }

        public void Update(params OrderViewModel[] orderViewModels)
        {
            throw new NotImplementedException();
        }

        public void Remove(params OrderViewModel[] orderViewModels)
        {
            throw new NotImplementedException();
        }
    }
}
