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

        List<Pizzas> GetByName(string name, int pageNumber);

        // Aquí tendrías que haber metido los dbset porque así podemos crear los constructores
        // del IPizzasRepository.
         
        //IEnumerable<Pizzas> toList(int capacity, Expression<Func<string,bool>> expression);

    }
}
