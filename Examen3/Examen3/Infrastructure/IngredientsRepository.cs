using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private PizzasIngredientsContext _context;

        public IngredientsRepository(PizzasIngredientsContext context)
        {
            this._context = context;
        }

        public void Add(Ingredients entity)
        {
            _context.Ingredients.Add(entity);
        }

        public void Delete(Ingredients entity)
        {
            _context.Ingredients.Remove(entity);
        }

        public Ingredients GetById(Guid id)
        {
            return _context.Ingredients.Find(id);
        }

        public void Update(Ingredients entity)
        {
            //
        }
    }
}
