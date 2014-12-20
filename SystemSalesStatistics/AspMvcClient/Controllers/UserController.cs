using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvcClient.Filters;
using BusinessLayer;
using PagedList;

namespace AspMvcClient.Controllers
{
    [RoledAuthorize]
    public class UserController : Controller
    {
        private readonly IWorker _worker = new Worker();

        public ActionResult List(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(_worker.GetAllOrders().ToOrderModels().ToPagedList(pageNumber, pageSize));
        }
    }
}
