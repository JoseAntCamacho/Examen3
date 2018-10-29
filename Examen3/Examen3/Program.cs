using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Examen3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List <Pizzas> lista = new List<Pizzas>()
            {
                new Pizzas { PizzasName = "carbonara"},
                new Pizzas { PizzasName = "cuatroquesos"},
                new Pizzas {PizzasName = "jamon"},
                new Pizzas {PizzasName = "salami"}
            };

            ICollection<Ingredients> ingredientes = new List<Ingredients>()
            {
                new Ingredients {IngredientsName = "queso",
                    IngredientsPrice=1, IngredientsCantity=2},
                new Ingredients {IngredientsName = "nata",
                    IngredientsCantity=1.8M, IngredientsPrice = 1}
            };

            ICollection<Ingredients> ingredientes2 = new List<Ingredients>()
            {
                new Ingredients {IngredientsName = "queso",
                    IngredientsCantity =1.1M, IngredientsPrice=1},
                new Ingredients {IngredientsName = "queso suave",
                    IngredientsCantity =1.2M, IngredientsPrice=2}
            };

            lista[0].IngredientsLinks = ingredientes;
            lista[1].IngredientsLinks = ingredientes2;

            /*using(var db = new PizzasIngredientsContext())
            {
                var pizzaRepository = new PizzasRepository(db);
                foreach (var item in lista)
                {
                    pizzaRepository.Add(item);                    
                }
                db.SaveChanges();
            }*/

            /*using (var db= new PizzasIngredientsContext())
            {
                var pizzaRepository = new PizzasRepository(db);
                var list = pizzaRepository.GetByName("");
                foreach(var item in list)
                {
                    Console.WriteLine(item.PizzasName);
                }
            }*/

            Console.ReadKey();


        }
    }
}
