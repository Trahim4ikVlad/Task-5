using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;
using BusinessLayer.Specification;
using DataAccessLayer;

namespace BusinessLayer
{
    public interface IWorker
    {
        IEnumerable<OrderDto> GetAllOrders();

        IList<OrderDto> GetOrders(Func<Order, bool> where);
        OrderDto GetOrderBy(int id);

        IEnumerable<OrderDto> Search(SearchSpecification specification);

        IEnumerable<OrderDto> OrderBy(Func<OrderDto, string> where);

        void Add(OrderDto orderDto);
        void Update(OrderDto orderDto);
        void Remove(OrderDto orderDto);
    }
}
