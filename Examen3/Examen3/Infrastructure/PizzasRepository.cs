using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace Examen3
{
    public class PizzasRepository : IPizzasRepository
    {
        private readonly PizzasIngredientsContext _context;

        public PizzasRepository(PizzasIngredientsContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Pizzas entity)
        {
            _context.Pizzas.Add(entity);            
        }

        public void Delete(Pizzas entity)
        {
            _context.Pizzas.Remove(entity);
        }

        public Pizzas GetById(Guid id)
        {
            return _context.Pizzas.Find(id);
        }

        public Task<Pizzas> GetByIdAsync(Guid id)
        {
            return _context.Pizzas.FindAsync(id);
        }

        public List<Pizzas> GetByName(string name, int pageNumber = 1)
        {
            
            var result = new List<Pizzas>();
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["CapacityOfView"], 10);
            
            if (name != null && name != "")
            {
                //comentado la implementación sin linq.
                /*Pizzas pizza = null;
                foreach (var item in _context.Pizzas)
                {
                    if (item.PizzasName.Equals(name))
                    {
                        pizza = item;
                    }
                }
                result.Add(pizza);*/

                try
                {
                    var pizza = _context.Pizzas.FirstOrDefault(p => p.PizzasName == name);
                    if (pizza == null) throw new Exception("No se ha encontrado la pizza");
                    result.Add(pizza);                
                    return result;
                }
                catch(Exception ex)
                {
                    throw new Exception("No se ha encontrado la pizza");
                }                
            }
            result = PaginedPizzas(pageNumber, pageSize, _context.Pizzas.ToList());
            return result;
        }
        
        public List<Pizzas> PaginedPizzas(int pageNumber, int pageSize, List<Pizzas> pizzas)
        {
            var result = new List<Pizzas>();
            if (pizzas.Count < pageSize)
            {
                return pizzas;
            }
            for(var i = (pageNumber-1)*pageSize; i < pageSize * pageNumber; i++)
            {
                result.Add(pizzas[i]);
            }
            return result;
        }

        public void Update(Pizzas entity)
        {
            var result = _context.Pizzas.SingleOrDefault(b => b.PizzasId == entity.PizzasId);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                }
                catch (Exception ex)
                {
                    throw new Exception("No se ha encontrado la pizza que quiere actualizar");
                }
            }
        }
    }

    // cómo se debería hacer el ejercicio 3. Esto debería estar en el dominio porque es lo que pide
    // el cliente.
    public class PizzaFilter
    {
        public static Func<Pizzas, bool> FindByName (string name)
        {
            Func<Pizzas, bool> result = (p) => (p.PizzasName.Contains(name) || name == null);
            return result;
        }

        // y entonces podríamos hacer...
        //  _context.Pizzas.Where(PizzaFilter.FindByName(""));
        // si lo queremos paginar usa los métodos que ya existen...
        // _context.Pizzas.Where(PizzaFilter.FindByName("")).Skip((page - 1) * pageSize).Take(pageSize);

    }


}
