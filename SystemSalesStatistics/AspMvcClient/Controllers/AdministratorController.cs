using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AspMvcClient.Models;
using BusinessLayer;
using AutoMapper;
using BusinessLayer.DTOEntity;
using WebMatrix.WebData;


namespace AspMvcClient.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        //
        // GET: /Administrator/
        private readonly IWorker _worker = new Worker();
        

        public ActionResult List()
        {
            IList<OrderModel> orderModels = _worker.GetAllOrders().ToOrderModels();
            return View(orderModels);
        }
         
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                if(orderModel!=null)
                _worker.Add(orderModel.ToOrderDto());
                return RedirectToAction("List");
            }
            else
            {
                return View(orderModel);
            }
        }

    }

    public static class ExtensionsMethod
    {
        public static ClientModel ToClientModel(this ClientDto clientDto)
        {
            return new ClientModel()
            {
                Id = (int) clientDto.Id,
                Name = clientDto.Name
            };
        }

        public static IList<OrderModel> ToOrderModels(this IEnumerable<OrderDto> orderDtos)
        {
            return orderDtos.Select(order => order.ToOrderModel()).ToList();
        }

        public static IList<ClientModel> ToClientModels(this IEnumerable<ClientDto> clientDtos)
        {
            return clientDtos.Select(client => client.ToClientModel()).ToList();
        }

        public static IList<ManagerModel> ToManagerModels(this IEnumerable<ManagerDto> managerDtos )
        {
            return managerDtos.Select(manager => manager.ToManagerModel()).ToList();
        }
        public static ManagerModel ToManagerModel(this ManagerDto managerDto)
        {
            return new ManagerModel()
            {
                Id = (int) managerDto.ID,
                Name = managerDto.Name
            };
        }

        public static OrderModel ToOrderModel(this OrderDto orderDto)
        {
            return new OrderModel()
            {
                Id = (int) orderDto.Id,
                Client = ToClientModel(orderDto.Client),
                Manager = ToManagerModel(orderDto.Manager),
                Cost = orderDto.Cost,
                OrderDate = orderDto.OrderDate,
                ProductName = orderDto.ProductName
            };
        }

        public static OrderDto ToOrderDto(this OrderModel orderModel)
        {
            return new OrderDto()
            {
                Id = orderModel.Id,
                Client = orderModel.Client.ToClientDto(),
                Manager = orderModel.Manager.ToManagerDto(),
                Cost = orderModel.Cost,
                OrderDate = orderModel.OrderDate,
                ProductName = orderModel.ProductName
            };
        }

        public static ManagerDto ToManagerDto(this ManagerModel managerModel)
        {
            return new ManagerDto()
            {
                Name = managerModel.Name,
                ID = managerModel.Id
            };
        }

        public static ClientDto ToClientDto(this ClientModel clientModel)
        {
            return new ClientDto()
            {
                Id = clientModel.Id,
                Name = clientModel.Name
            };
        }
    }
}
