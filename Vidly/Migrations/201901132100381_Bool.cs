namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean());
        }
    }
}
