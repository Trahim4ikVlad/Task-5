using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace AspMvcClient.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        //
        // GET: /Administrator/
        private IWorker _worker;

        AdministratorController()
        {
            _worker = new Worker();
        }

        public ActionResult List()
        {
            return View(_worker.GetAllOrders());
        }

    }
}
