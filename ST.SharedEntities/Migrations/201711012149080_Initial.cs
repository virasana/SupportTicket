namespace ST.SharedEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Severity",
                c => new
                    {
                        SeverityId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SeverityId);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        SeverityId = c.Int(nullable: false),
                        Problem = c.String(nullable: false, maxLength: 1000, unicode: false),
                        Description = c.String(nullable: false, maxLength: 30, unicode: false),
                        ProductId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Severity", t => t.SeverityId, cascadeDelete: true)
                .Index(t => t.SeverityId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "SeverityId", "dbo.Severity");
            DropForeignKey("dbo.Ticket", "ProductId", "dbo.Product");
            DropIndex("dbo.Ticket", new[] { "ProductId" });
            DropIndex("dbo.Ticket", new[] { "SeverityId" });
            DropTable("dbo.Ticket");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Severity");
            DropTable("dbo.Product");
        }
    }
}
