using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class Extensions
    {
        public static IEnumerable<OrderViewModel> ToOrderViewModelsOrders(this IEnumerable<Order> orders)
        {
            return orders.Select(order => order.ToOrderViewModel()).ToList();
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            
            OrderViewModel viewModel = new OrderViewModel()
            {
                Id = order.ID,
                OrderDate = order.OrderDate,
                Cost = order.Cost,
                ProductName = order.ProductName
            };

           

            return new OrderViewModel()
            {
               
                ClientName = order.Client.Name,
                
                ManagerName = order.Manager.Name,
               
            };
        }
    }
}
