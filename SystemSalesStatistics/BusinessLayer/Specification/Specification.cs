using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Specification
{
    public abstract class Specification<T> where T : class, new()
    {
        public abstract bool IsSatisfiedBy(T obj);

    }

}
