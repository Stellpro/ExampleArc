
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleArc.Core.Abstraction
{
    public interface IRepository<T> where T : class
    {
         Task<List<T>> Get();

         Task<T> Create(T p);

         Task<T> Update(T p);

         Task Delete(T p);
    }
}
