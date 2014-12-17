using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;

namespace BusinessLayer.Specification
{
    public class ProductOrdersSpecification:IOrderSpecification
    {
        private readonly string _productName;

        public ProductOrdersSpecification(string productName)
        {
            _productName = productName;
        }

        public IEnumerable<OrderDto> SatisfiedBy(IEnumerable<OrderDto> orders)
        {
            return _productName!=null ? orders.Where(x => x.ProductName == _productName) : orders;
        }
    }
}
