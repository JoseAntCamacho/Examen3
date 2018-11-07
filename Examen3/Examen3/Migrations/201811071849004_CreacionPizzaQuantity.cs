namespace Examen3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionPizzaQuantity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PizzasIngredientsQuantities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredients_IngredientsId = c.Guid(),
                        Pizzas_PizzasId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.Ingredients_IngredientsId)
                .ForeignKey("dbo.Pizzas", t => t.Pizzas_PizzasId)
                .Index(t => t.Ingredients_IngredientsId)
                .Index(t => t.Pizzas_PizzasId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzasIngredientsQuantities", "Pizzas_PizzasId", "dbo.Pizzas");
            DropForeignKey("dbo.PizzasIngredientsQuantities", "Ingredients_IngredientsId", "dbo.Ingredients");
            DropIndex("dbo.PizzasIngredientsQuantities", new[] { "Pizzas_PizzasId" });
            DropIndex("dbo.PizzasIngredientsQuantities", new[] { "Ingredients_IngredientsId" });
            DropTable("dbo.PizzasIngredientsQuantities");
        }
    }
}
