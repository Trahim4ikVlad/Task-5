using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.DTOEntity;
using BusinessLayer.Mappers;
using DataAccessLayer;
using AutoMapper;

namespace BusinessLayer
{
    public class Worker:IWorker
    {
        private readonly IRepository _repository;
        private OrderMapper _mapper;
       

        public Worker()
        {
           _repository = new Repository();
           _mapper = new OrderMapper();
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
            _repository.Update(_mapper.Map(orderDto));
        }
       
        public void Remove(OrderDto orderDto)
        {
            _repository.Remove(ToOrder(orderDto));
        }

        private Order ToOrder(OrderDto orderDto)
        {
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
                Name = clientDto.Name
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


        /*
        public void Add(params OrderViewModel[] orderViewModels)
        {
            foreach (OrderViewModel model in orderViewModels)
            {
                var client = _clientRepository.GetSingle(x => x.Name == model.ClientName);
                var manager = _managerRepository.GetSingle(x => x.Name == model.ManagerName);
                
                if (client == null)
                {
                    client = new Client()
                    {
                        Name = model.ClientName
                    };

                    _clientRepository.Add(client);
                }
                if (manager == null)
                {
                    manager = new Manager()
                    {
                        Name = model.ManagerName
                    };
                    _managerRepository.Add(manager);
                }

                _orderRepository.Add(ToOrder(model));
            }
            
        }

        public void Update(params OrderViewModel[] orderViewModels)
        {
            foreach (OrderViewModel viewModel in orderViewModels)
            {
                _orderRepository.Update(ToOrder(viewModel));
            }
        }

        public void Remove(params OrderViewModel[] orderViewModels)
        {
            foreach (OrderViewModel viewModel in orderViewModels)
            {
                _orderRepository.Remove(ToOrder(viewModel));
            }    
        }*/
    }
}
