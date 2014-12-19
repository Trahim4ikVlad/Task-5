using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.DTOEntity;
using BusinessLayer.Mappers;
using BusinessLayer.Specification;
using DataAccessLayer;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorker worker = new Worker();

            OrderModel model = new OrderModel()
            {
               ManagerName = "Petuxov",
                ClientName = "Qetynov",
              Cost = 20,
               OrderDate = DateTime.Now,
             ProductName = "Orbit"
           };

            worker.Add(model.ToOrderDto());

            OrderDto order = worker.Search(new SearchSpecification()
            {
                ProductName = "Orbit"
            }).FirstOrDefault();

            worker.Remove(order);
        }
    }
    public class OrderModel
    {
        public int? Id { get; set; }

        public System.DateTime OrderDate { get; set; }

        public string ProductName { get; set; }

        public double Cost { get; set; }

        public string ClientName { get; set; }

        public string ManagerName { get; set; }
    }

    public static class ExtensionsMethod
    {
        public static IEnumerable<OrderModel> ToOrderModels(this IEnumerable<OrderDto> orderDtos)
        {
            return orderDtos.Select(order => order.ToOrderModel()).ToList();
        }

        public static OrderModel ToOrderModel(this OrderDto orderDto)
        {
            return new OrderModel()
            {
                Id = orderDto.Id,
                ClientName = orderDto.Client.Name,
                ManagerName = orderDto.Manager.Name,
                Cost = orderDto.Cost,
                OrderDate = orderDto.OrderDate,
                ProductName = orderDto.ProductName
            };
        }

        public static OrderDto ToOrderDto(this OrderModel model)
        {

            return new OrderDto()
            {
                Client = new ClientDto()
                {
                    Name = model.ClientName
                },
                Manager = new ManagerDto()
                {
                    Name = model.ManagerName
                },
                Id = model.Id,
                Cost = model.Cost,
                OrderDate = model.OrderDate,
                ProductName = model.ProductName
            };
        }

        public static IEnumerable<OrderDto> ToOrderDtos(this IEnumerable<OrderModel> orderModels)
        {
            return orderModels.Select(x => x.ToOrderDto());
        }

    }
}

