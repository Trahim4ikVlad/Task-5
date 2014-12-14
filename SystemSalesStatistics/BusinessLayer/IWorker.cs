using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public interface IWorker
    {
        IList<OrderViewModel> GetAllOrders();

        IList<OrderViewModel> FilterBy(Func<Order, bool> where);
        IList<OrderViewModel> FilterBy(params Expression<Func<Order, object>>[] navigationProperties);

        void Add(params OrderViewModel[] orderViewModels);
        void Update(params OrderViewModel[] orderViewModels);
        void Remove(params OrderViewModel[] orderViewModels);
    }
}
