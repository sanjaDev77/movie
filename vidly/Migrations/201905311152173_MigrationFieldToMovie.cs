namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationFieldToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Mig", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Mig");
        }
    }
}
