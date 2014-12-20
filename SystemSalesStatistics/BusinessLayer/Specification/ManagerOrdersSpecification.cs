using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;

namespace BusinessLayer.Specification
{
    public class ManagerOrdersSpecification:IOrderSpecification
    {
        private readonly string _managerName;

        public ManagerOrdersSpecification(string managerName)
        {
            _managerName = managerName;
        }

        public IEnumerable<OrderDto> SatisfiedBy(IEnumerable<OrderDto> orders)
        {
            return !String.IsNullOrEmpty(_managerName) ? orders.Where(x => x.Manager.Name.Contains(_managerName)) : orders;
        }
    }
}
