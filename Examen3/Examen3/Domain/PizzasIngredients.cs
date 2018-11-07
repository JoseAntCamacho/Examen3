using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{
    public class PizzasIngredients
    {
        [Key]
        [Column(Order =0)]
        public Guid PizzasId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid IngredientsId { get; set; }

        

        public virtual Pizzas Pizzas { get; set; }
        public virtual Ingredients Ingredients { get; set; }

    }

    public class PizzasIngredientsQuantity
    {
        public Guid Id { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        public Pizzas Pizzas { get; set; }
        public Ingredients Ingredients { get; set; }
    }
}
