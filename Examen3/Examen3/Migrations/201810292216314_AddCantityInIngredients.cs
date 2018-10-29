namespace Examen3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCantityInIngredients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "IngredientsCantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredients", "IngredientsCantity");
        }
    }
}
