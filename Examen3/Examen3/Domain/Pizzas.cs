using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public decimal CalculatePrice()
        {
            decimal value = 0;
            foreach(var item in IngredientsLinks)
            {
                value += item.IngredientsPrice;
            }
            return value;
        }

    }
}
