using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;

namespace BusinessLayer.Specification
{
    public class DateOrdersSpecification:IOrderSpecification
    {
        private readonly DateTime _dateTime;

        public DateOrdersSpecification(DateTime date)
        {
            _dateTime = date;
        }

        public IEnumerable<OrderDto> SatisfiedBy(IEnumerable<OrderDto> orders)
        {
            if (_dateTime != null) return orders.Where(x => x.OrderDate == _dateTime);
            return orders;
        }
    }
}
