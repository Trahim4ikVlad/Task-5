using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;
using DataAccessLayer;

namespace BusinessLayer
{
    public interface IWorker
    {
        IList<OrderDto> GetAllOrders();
        IList<OrderDto> GetOrders(Func<Order, bool> where);

        void Add(OrderDto orderDto);
        void Update(OrderDto orderDto);
        void Remove(OrderDto orderDto);
    }
}
