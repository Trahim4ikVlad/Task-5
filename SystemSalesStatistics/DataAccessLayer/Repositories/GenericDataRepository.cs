using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class, new() 
    {
        public IList<T> GetAll()
        {
            List<T> list = null;

            using (var context = new DBEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                list = dbQuery.ToList();
            }

            return list;
        }

        public IList<T> GetList(Func<T, bool> wheres)
        {
            List<T> list = null;
            using (var contex = new DBEntities())
            {
                IQueryable<T> dbQuery = contex.Set<T>();
                list = dbQuery.Where(wheres).ToList();
            }
            return list;
        }
       
        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new DBEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }


        public T GetSingle(Func<T, bool> where)
        {
            T single = null;
            using (var contex = new DBEntities())
            {
                IQueryable<T> dbQuery = contex.Set<T>();
                single = dbQuery.FirstOrDefault(where);
            }
            return single;
        }

        public void Add(params T[] items)
        {
            using (var context = new DBEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public void Update(params T[] items)
        {
            using (var context = new DBEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void Remove(params T[] items)
        {
            using (var context = new DBEntities())
            {
                foreach (T item in items)
                { 
                    context.Entry(item).State = System.Data.EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
    }
}
