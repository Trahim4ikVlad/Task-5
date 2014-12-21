using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspMvcClient.Controllers;
using AspMvcClient.Models;
using BusinessLayer;

namespace AspMvcClient.RepoCharts
{
    public class Service
    {
        private IWorker _worker;

        public Service()
        {
            _worker = new Worker();
        }

        public IEnumerable ListData()
        {
            var datasGroups = _worker.GetAllOrders().ToOrderModels().GroupBy(x => x.ManagerName);

            List<DataChartModel> datas = datasGroups.Select(datasGroup => new DataChartModel()
            {
                ManagerName = datasGroup.Key, SumOrders = datasGroup.Sum(x => x.Cost)
            }).ToList();

            var inem = datas.AsEnumerable();

            return inem;
        }
    }
}