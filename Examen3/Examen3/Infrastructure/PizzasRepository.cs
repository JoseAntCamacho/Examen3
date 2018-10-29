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
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["Capacity"], 10);
            
            if (name != null)
            {
                try
                {
                    var pizza = _context.Pizzas.FirstOrDefault(p => p.PizzasName == name);
                    result.Add(pizza);                
                    return result;
                }
                catch(Exception ex)
                {
                    throw new Exception("No se ha encontrado la pizza");
                }
                
            }            
            result = PaginedPizzas(pageNumber, pageSize,_context.Pizzas.ToList());
            return result;
        }

        public List<Pizzas> PaginedPizzas(int pageNumber, int pageSize, List<Pizzas> pizzas)
        {
            var result = new List<Pizzas>();
            if (pizzas.Count < pageSize)
            {
                return pizzas;
            }
            for(var i = pageNumber*pageSize; i < pageSize * (pageNumber + 1); i++)
            {
                result.Add(pizzas[i]);
            }
            return pizzas;
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

    
}
