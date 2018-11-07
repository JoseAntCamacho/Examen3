using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PagedList;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen3
{
    // es disposable.
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }

    public class PizzasIngredientsContext : DbContext, IUnitOfWork
    {
        public PizzasIngredientsContext() : base("name=Examen3")
        {

        }
        public DbSet<Pizzas> Pizzas { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<PizzasIngredientsQuantity> pizzasIngredientsQuantities { get; set; }

        public IEnumerable<Pizzas> toList(int page, int capacity, Expression<Func<Pizzas, bool>> expression)
        {
            return this.Pizzas.Where(expression).ToPagedList(page, capacity);
        }

    }
}
