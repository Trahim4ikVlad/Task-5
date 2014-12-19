using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AspMvcClient.Models;
using BusinessLayer;
using AutoMapper;
using BusinessLayer.DTOEntity;
using BusinessLayer.Specification;
using WebMatrix.WebData;


namespace AspMvcClient.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
       private  readonly IWorker _worker = new Worker();


        public ActionResult List()
        {
            return View(_worker.GetAllOrders().ToOrderModels());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderModel orderModel)
        {

            if (orderModel != null)
            {
                _worker.Add(orderModel.ToOrderDto());
            }

            return RedirectToAction("List"); ;
        }

        [HttpGet]
        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            OrderModel orderModel = _worker.GetOrder(x=>x.Id ==id).ToOrderModel();
            return View(orderModel);
        }

        [HttpPost]
        public ActionResult EditOrder(OrderModel order)
        {
            _worker.Update(order.ToOrderDto());
            return RedirectToAction("List");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel model = _worker.GetOrder(x=>x.Id==id).ToOrderModel();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        /*
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            if (model != null)
            {
                //_worker.Search(model.ToSearchSpecification());
            }
            return View();
        }
        */
    }
    #region
    
    public static class ExtensionsMethod
    {

        public static SearchSpecification ToSearchSpecification(this SearchModel model)
        {
            return new SearchSpecification()
            {
                ClientName = model.ClientName,
                ManagerName = model.ManagerName,
                OrderDate = model.OrderDate,
                ProductName = model.ProductName
            };
        }

        public static IEnumerable<OrderModel> ToOrderModels(this IEnumerable<OrderDto> orderDtos)
        {
            return orderDtos.Select(order => order.ToOrderModel()).ToList();
        }
        public static OrderModel ToOrderModel(this OrderDto orderDto)
        {
            return new OrderModel()
            {
                Id =  orderDto.Id,
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

        public static IEnumerable<OrderDto> ToOrderDtos(this IEnumerable<OrderModel>  orderModels)
        {
            return orderModels.Select(x => x.ToOrderDto());
        }
        
    }
    #endregion
}
