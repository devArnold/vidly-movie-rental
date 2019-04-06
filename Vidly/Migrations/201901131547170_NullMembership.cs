namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullMembership : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
    }
}
