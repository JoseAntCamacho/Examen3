using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{
    // el repositorio no tiene que comprobar que si está o no está la entidad...
    // solo tiene que hacerlo.
    public class IngredientsRepository : IIngredientsRepository
    {
        private PizzasIngredientsContext _context;

        // aquí rompes el SOLID... no trabajes con clases, trabaja con interfaces.

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

        public IEnumerable<Pizzas> toList(int page, int capacity, Expression<Func<Pizzas, bool>> expression)
        {
            return _context.Pizzas.Where(expression).ToPagedList(page, capacity);
        }

        public void Update(Ingredients entity) // este está mal hecho.
        {
            var result = _context.Ingredients.SingleOrDefault(b => b.IngredientsId == entity.IngredientsId);

            if (result != null)
            {
                try
                {// solo hay que poner esta línea.
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
