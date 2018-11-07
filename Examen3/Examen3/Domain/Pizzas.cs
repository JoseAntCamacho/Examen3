using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Examen3
{
    public class Pizzas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PizzasId { get; private set; }
        [Required]
        public string PizzasName { get; set; }

        [ForeignKey("PizzasId")]
        public virtual ICollection<Ingredients> IngredientsLinks { get; set; }

        public virtual ICollection<PizzasIngredientsQuantity> PizzasIngredientsQuantities { get; set; }


        // Tenemos un commit para el versionado.
        // método que calcula el precio de la pizza antes del ejercicio 4.
        /*public decimal CalculatePrice()
        {
            decimal profit = Convert.ToDecimal(ConfigurationManager.AppSettings["Profits"]);
            decimal value = 0;
            foreach(var item in IngredientsLinks)
            {
                value += item.IngredientsPrice;
            }
            return value*profit;
        }*/

        public decimal CalculatePrice()
        {
            decimal profit = Convert.ToDecimal(ConfigurationManager.AppSettings["Profits"]);
            return profit * this.PizzasIngredientsQuantities.Sum(c => c.Ingredients.IngredientsPrice * c.Quantity);
        }


    }
}
