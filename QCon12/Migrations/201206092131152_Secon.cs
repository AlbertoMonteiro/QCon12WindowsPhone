using System.Data.Entity.Migrations;

namespace QCon12.Migrations
{
    public partial class Secon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Palestras", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Palestras", "Palestrante_Id", "dbo.Palestrantes");
            DropIndex("dbo.Palestras", new[] {"Track_Id"});
            DropIndex("dbo.Palestras", new[] {"Palestrante_Id"});
            RenameColumn(table: "dbo.Palestras", name: "Track_Id", newName: "TrackId");
            RenameColumn(table: "dbo.Palestras", name: "Palestrante_Id", newName: "PalestranteId");
            AddForeignKey("dbo.Palestras", "TrackId", "dbo.Tracks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Palestras", "PalestranteId", "dbo.Palestrantes", "Id", cascadeDelete: true);
            CreateIndex("dbo.Palestras", "TrackId");
            CreateIndex("dbo.Palestras", "PalestranteId");
        }

        public override void Down()
        {
            DropIndex("dbo.Palestras", new[] {"PalestranteId"});
            DropIndex("dbo.Palestras", new[] {"TrackId"});
            DropForeignKey("dbo.Palestras", "PalestranteId", "dbo.Palestrantes");
            DropForeignKey("dbo.Palestras", "TrackId", "dbo.Tracks");
            RenameColumn(table: "dbo.Palestras", name: "PalestranteId", newName: "Palestrante_Id");
            RenameColumn(table: "dbo.Palestras", name: "TrackId", newName: "Track_Id");
            CreateIndex("dbo.Palestras", "Palestrante_Id");
            CreateIndex("dbo.Palestras", "Track_Id");
            AddForeignKey("dbo.Palestras", "Palestrante_Id", "dbo.Palestrantes", "Id");
            AddForeignKey("dbo.Palestras", "Track_Id", "dbo.Tracks", "Id");
        }
    }
}