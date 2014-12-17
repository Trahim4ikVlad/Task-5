using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Specification
{
    public interface ISpecification <TEntity> 
    {
        IEnumerable<TEntity> SatisfiedBy(IEnumerable<TEntity> orders);
    }

}
