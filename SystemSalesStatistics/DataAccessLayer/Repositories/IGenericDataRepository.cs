using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IGenericDataRepository<T> where T :  new()
    {
        IList<T> GetAll();
        IList<T> GetList(Func<T, bool> wheres);

        IList<T> GetList(Func<T, bool> where,
            params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where);

        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }

}
