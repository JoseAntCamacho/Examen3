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

        /*Necesitamos un método que busque por nombre y si no hay nombre entonces que me devuelva
            una lista con las primeras 15 que haya.*/

        List<Pizzas> GetByName(string name);

        
         
        //IEnumerable<Pizzas> toList(int capacity, Expression<Func<string,bool>> expression);

    }
}
