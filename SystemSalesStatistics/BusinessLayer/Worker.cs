using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.DTOEntity;
using BusinessLayer.Specification;
using DataAccessLayer;


namespace BusinessLayer
{
    public class Worker:IWorker
    {
        private readonly IRepository _repository;

        public Worker()
        {
           _repository = new Repository();
        }

        public IList<OrderDto> GetAllOrders()
        {
            return _repository.GetOrders().Select(order => ToOrderDto(order)).ToList();
        }

        public IList<OrderDto> GetOrders(Func<Order, bool> where)
        {
            return _repository.GetOrders(@where).Select(order => ToOrderDto(order)).ToList();
        }

        public OrderDto GetOrder(Func<Order, bool> @where)
        { 
            Order order = _repository.GetOrder(where);
            return ToOrderDto(order);
        }

        public IEnumerable<OrderDto> Search(SearchSpecification specification)
        {
            return specification.SatisfiedBy(GetAllOrders());
        }

        public void Add(OrderDto orderDto)
        {
            var client = _repository.GetClient(x => x.Name == orderDto.Client.Name);
            var manager = _repository.GetManager(x => x.Name == orderDto.Manager.Name);

            if (client == null)
            {
                client = ToClient(orderDto.Client);
                _repository.Add(client);
            }
            if (manager == null)
            {
                manager = ToManager(orderDto.Manager);
                _repository.Add(manager);
            }
            _repository.Add(ToOrder(orderDto));
        }

        public void Update(OrderDto orderDto)
        {

            Client client = _repository.GetClient(x=>x.ID==orderDto.Client.Id);

            if (client.Name != orderDto.Client.Name)
            {
                client.Name = orderDto.Client.Name;
                _repository.Update(client);
            }
            Manager manager = _repository.GetManager(x => x.ID == orderDto.Manager.ID);
            if (manager.Name != orderDto.Manager.Name)
            {
                manager.Name = orderDto.Manager.Name;
                _repository.Update(manager);
            }

            _repository.Update(ToOrder(orderDto));
        }
       
        public void Remove(OrderDto orderDto)
        {
            _repository.Remove(ToOrder(orderDto));
        }

        #region conversion
        private Order ToOrder(OrderDto orderDto)
        {
            return new Order()
            {
                ID = (int) orderDto.Id,
                Client = ToClient(orderDto.Client),
                Manager = ToManager(orderDto.Manager),
                ClientID = (int) orderDto.Client.Id,
                ManagerID = (int) orderDto.Manager.ID,
                ProductName = orderDto.ProductName,
                Cost = orderDto.Cost,
                OrderDate = orderDto.OrderDate,
            };
        }

        private Client ToClient(ClientDto clientDto)
        {
            Client client = _repository.GetClient(x => x.Name == clientDto.Name);

            return new Client()
            {
                ID = client.ID,
                Name = clientDto.Name
            };
        }

        private Manager ToManager(ManagerDto managerDto)
        {
            return new Manager()
            {
                ID = (int) managerDto.ID,
                Name = managerDto.Name
            };
        }
        private OrderDto ToOrderDto(Order order)
        {
            return new OrderDto()
            {
                Id = order.ID,
                Cost = order.Cost,
                OrderDate = order.OrderDate,
                ProductName = order.ProductName,
                Client = ToClientDto(_repository.GetClient(x => x.ID == order.ClientID)),
                Manager = ToManagerDto(_repository.GetManager(x => x.ID == order.ManagerID))
            };
        }

        private ClientDto ToClientDto(Client client)
        {
            return new ClientDto()
            {
                Id = client.ID,
                Name = client.Name
            };
        }

        private ManagerDto ToManagerDto(Manager manager)
        {
            return new ManagerDto()
            {
                ID = manager.ID,
                Name = manager.Name
            };
        }
        #endregion
   }
}
