using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{
    interface IPizzasRepository: IRepository<Pizzas>
    {

        IEnumerable<Pizzas> toList(int capacity, Expression<Func<string,bool>> expression);

    }
}
