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
        // esto tiene que ser así porque el GUID puede que no lo soporte.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // aquí rompes con las convention de EF. no tiene que llevar el ingredients
        public Guid IngredientsId { get; private set; } 
        [Required]
        public string IngredientsName { get; set; }
        [Required]
        public decimal IngredientsPrice { get; set; }

        // Para una pizza y para un ingrediente determinado tengo una cantidad determinada.
        // esto no puede estar aquí. Ha de estar en una nueva entidad que tenga Pizza, ingrediente y cantidad.
        [Required]
        [CustomValidation(typeof(GreaterThanOne), "ValidationCantity")]
        public decimal IngredientsCantity { get; set; }

        [ForeignKey("IngredientsId")] // esto no haría falta si quitamos el Ingredients de cada nombre
        public virtual ICollection<Pizzas> PizzaLinks { get; set; }
        // el virtual está aquí porque así solamente nos traemos los datos cuando accedemos a la propiedad.
    }
}
