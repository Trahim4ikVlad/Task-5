using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;
using DataAccessLayer;

namespace BusinessLayer.Mappers
{
    public  class OrderMapper:MapperBase<Order, OrderDto>
    {
        private readonly ManagerMapper _managerMapper = new ManagerMapper();
        private readonly ClientMapper _clientMapper = new ClientMapper();

        public OrderMapper()
        {
        }

        public override Order Map(OrderDto element)
        {
            return new Order()
            {
                Client = _clientMapper.Map(element.Client),
                Cost = element.Cost,
                OrderDate = element.OrderDate,
                ProductName = element.ProductName,
                Manager = _managerMapper.Map(element.Manager)
            };
        }

        public override OrderDto Map(Order element)
        {
            return new OrderDto()
            {
                Client = _clientMapper.Map(element.Client),
                Manager = _managerMapper.Map(element.Manager),
                Cost = element.Cost,
                OrderDate = element.OrderDate,
                ProductName = element.ProductName
            };
        }
    }
}
