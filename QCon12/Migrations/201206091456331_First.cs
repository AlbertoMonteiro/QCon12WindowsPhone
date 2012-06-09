using System.Data.Entity.Migrations;

namespace QCon12.Migrations
{
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "Logo", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Tracks", "Logo");
        }
    }
}