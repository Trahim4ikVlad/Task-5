using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IGenericDataRepository<T> where T : class
    {
        IList<T> GetAll();
        IList<T> GetList(Func<T, bool> wheres);

        T GetSingle(Func<T, bool> where);

        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }

}
