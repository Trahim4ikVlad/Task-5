using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using AspMvcClient.Models;
using AspMvcClient.RepoCharts;
using BusinessLayer;

namespace AspMvcClient.Controllers
{
    public class DisplayChartsController : Controller
    {
        //
        // GET: /DisplayCharts/
        private IWorker _worker;

        public DisplayChartsController()
        {
            _worker = new Worker();
        }

        public ActionResult Index()
        {
            return View();
        }

        [WebMethod]
        public JsonResult GetList()
        {
           Service service = new Service();
            var data = service.ListData();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
