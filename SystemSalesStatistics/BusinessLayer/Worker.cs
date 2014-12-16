using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;
using BusinessLayer.Mappers;
using DataAccessLayer;
using DataAccessLayer.Repositories;
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
            return _mapper.Map(_repository.GetOrders());
        }

        public IList<OrderDto> GetOrders(Func<Order, bool> where)
        {
            return _mapper.Map(_repository.GetOrders(where));
        }

        public void Add(OrderDto orderDto)
        {
            _repository.Add(_mapper.Map(orderDto));
        }

        public void Update(OrderDto orderDto)
        {
            _repository.Update(_mapper.Map(orderDto));
        }
       
        public void Remove(OrderDto orderDto)
        {
            _repository.Remove(_mapper.Map(orderDto));
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
