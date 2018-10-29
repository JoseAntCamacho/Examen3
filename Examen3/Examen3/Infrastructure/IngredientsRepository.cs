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
            this._context = context ?? throw new ArgumentNullException(nameof(context));
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

        public Task<Ingredients> GetByIdAsync(Guid id)
        {
            return _context.Ingredients.FindAsync(id);
        }

        public void Update(Ingredients entity)
        {
            var result = _context.Ingredients.SingleOrDefault(b => b.IngredientsId == entity.IngredientsId);

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
