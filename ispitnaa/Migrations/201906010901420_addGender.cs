namespace ispitnaa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Gender");
        }
    }
}
