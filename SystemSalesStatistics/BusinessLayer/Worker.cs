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

        public OrderDto GetOrder(Func<OrderDto, bool> @where)
        { 
            OrderDto order = ToOrderDto(_repository.GetOrder(@where as Func<Order, bool>));
            return order;
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
            Order order = _repository.GetOrder(x => x.ID == orderDto.Id);
            Client client = _repository.GetClient(x => x.ID == order.ClientID);
            Manager manager = _repository.GetManager(x => x.ID == order.ManagerID); 

            if (client.Name != orderDto.Client.Name)
            { 
                client.Name = orderDto.Client.Name;
                _repository.Update(client);
            }
             if (manager.Name != orderDto.Manager.Name)
            {
                manager.Name = orderDto.Manager.Name;
                _repository.Update(manager);
            }
             if (order.OrderDate != orderDto.OrderDate || 
                 order.Cost != orderDto.Cost || 
                 order.ProductName != orderDto.ProductName)
            {
                order.OrderDate = orderDto.OrderDate;
                order.Cost = orderDto.Cost;
                order.ProductName = orderDto.ProductName;
                _repository.Update(order);
            }   
        }
       
        public void Remove(OrderDto orderDto)
        {
            Order order = _repository.GetOrder(x => x.ID == orderDto.Id);
            _repository.Remove(order);
        }

        #region conversion
        private Order ToOrder(OrderDto orderDto)
        {
            Client client = _repository.GetClient(x => x.Name == orderDto.Client.Name);
            Manager manager = _repository.GetManager(x => x.Name == orderDto.Manager.Name);

            if (client != null && manager != null)
            {
                return new Order()
                {
                    ClientID = client.ID,
                    ManagerID = manager.ID,
                    //Client = client,
                    //Manager = manager,
                    ProductName = orderDto.ProductName,
                    Cost = orderDto.Cost,
                    OrderDate = orderDto.OrderDate,
                };
            }
            return new Order()
            {
                Client = ToClient(orderDto.Client),
                Manager = ToManager(orderDto.Manager),
                ProductName = orderDto.ProductName,
                Cost = orderDto.Cost,
                OrderDate = orderDto.OrderDate,
            };
            
        }

        private Client ToClient(ClientDto clientDto)
        {
            return new Client()
            {
                Name = clientDto.Name,
            };
        }

        private Manager ToManager(ManagerDto managerDto)
        {
            return new Manager()
            {
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
