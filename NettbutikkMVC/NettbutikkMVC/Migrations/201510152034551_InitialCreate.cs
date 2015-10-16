namespace NettbutikkMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kundes",
                c => new
                    {
                        KundeNR = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(nullable: false),
                        Etternavn = c.String(nullable: false),
                        TelefonNR = c.String(nullable: false),
                        Adresse = c.String(nullable: false),
                        PostNR = c.String(nullable: false),
                        PostSted = c.String(nullable: false),
                        Epost = c.String(nullable: false),
                        Passord = c.Binary(),
                    })
                .PrimaryKey(t => t.KundeNR);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kundes");
        }
    }
}
