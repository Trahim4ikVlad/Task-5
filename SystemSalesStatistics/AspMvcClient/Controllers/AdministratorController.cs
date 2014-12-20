using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AspMvcClient.Models;
using BusinessLayer;
using BusinessLayer.DTOEntity;
using BusinessLayer.Specification;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using WebMatrix.WebData;
using PagedList;
using PagedList.Mvc;

namespace AspMvcClient.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
       private  readonly IWorker _worker = new Worker();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(_worker.GetAllOrders().ToOrderModels().ToPagedList(pageNumber,pageSize));
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

        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            OrderModel orderModel = _worker.GetOrderBy((int) id).ToOrderModel();
            return View(orderModel);
        }

        [HttpPost]
        public ActionResult EditOrder(OrderModel order)
        {
            _worker.Update(order.ToOrderDto());
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            OrderModel orderModel = _worker.GetOrderBy((int)id).ToOrderModel();
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            OrderModel orderModel = _worker.GetOrderBy((int)id).ToOrderModel();
            if (orderModel == null)
            {
                return HttpNotFound();
            }

            _worker.Remove(orderModel.ToOrderDto());
            return RedirectToAction("List");
        }

        public ActionResult OrderSearch(string clientName, string managerName, string productName)
        {
            SearchModel search = new SearchModel()
            {
                ClientName = clientName,
            
            };

            var allorder = _worker.Search(search.ToSearchSpecification()).ToOrderModels();
            return PartialView(allorder);
        }
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
