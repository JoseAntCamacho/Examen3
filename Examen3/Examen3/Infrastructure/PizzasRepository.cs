using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{
    public class PizzasRepository : IPizzasRepository
    {
        private readonly PizzasIngredientsContext _context;

        public PizzasRepository(PizzasIngredientsContext context)
        {
            this._context = context;
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

        public IEnumerable<Pizzas> toList(int capacity, Expression<Func<string, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizzas entity)
        {
            throw new NotImplementedException();
        }
    }
}
