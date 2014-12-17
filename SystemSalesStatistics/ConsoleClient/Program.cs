using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DTOEntity;
using BusinessLayer.Mappers;
using DataAccessLayer;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            Client client = new Client()
            {
                ID = 1,
                Name = "Retut"
            };

            foreach (var order in worker.GetAllOrders())
            {
                Console.WriteLine(order.ProductName);
            }

            OrderDto orderDto = new OrderDto()
            {
                Manager = new ManagerDto()
                {
                    Name = "PEtrov"
                },
                Client = new ClientDto()
                {
                    Name = "Sososcin"
                },
                Cost = 250,
                OrderDate = DateTime.Now,
                ProductName = "Sup"
            };
            worker.Add(orderDto);
            //worker.Remove(orderDto);
        }
    }
}
