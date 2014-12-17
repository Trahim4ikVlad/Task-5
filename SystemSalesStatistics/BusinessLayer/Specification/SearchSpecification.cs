using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOEntity;

namespace BusinessLayer.Specification
{
    public class SearchSpecification:IOrderSpecification
    {
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public  string ManagerName { get; set; }
        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderDto> SatisfiedBy(IEnumerable<OrderDto> orders)
        {
            return
                new ProductOrdersSpecification(ProductName).SatisfiedBy(
                    new DateOrdersSpecification(OrderDate).SatisfiedBy(
                        new ManagerOrdersSpecification(ManagerName).SatisfiedBy(
                            new ClientOrdersSpecification(ClientName).SatisfiedBy(orders))));
        }
    }
}
