using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3
{


    public class Ingredients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IngredientsId { get; private set; }
        [Required]
        public string IngredientsName { get; set; }
        [Required]
        public decimal IngredientsPrice { get; set; }

        [Required]
        [CustomValidation(typeof(GreaterThanOne), "ValidationCantity")]
        public decimal IngredientsCantity { get; set; }

        [ForeignKey("IngredientsId")]
        public virtual ICollection<Pizzas> PizzaLinks { get; set; }
    }
}
