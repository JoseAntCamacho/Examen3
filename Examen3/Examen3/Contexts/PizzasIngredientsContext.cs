using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen3
{

    public interface IUnitOfWork
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



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
