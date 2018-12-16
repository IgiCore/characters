// ReSharper disable all

namespace IgiCore.Characters.Server.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Forename = c.String(nullable: false, maxLength: 100, unicode: false),
                        Middlename = c.String(maxLength: 100, unicode: false),
                        Surname = c.String(nullable: false, maxLength: 100, unicode: false),
                        DateOfBirth = c.DateTime(nullable: false, precision: 0),
                        Gender = c.Short(nullable: false),
                        Alive = c.Boolean(nullable: false, storeType: "bit"),
                        Health = c.Int(nullable: false),
                        Armor = c.Int(nullable: false),
                        Ssn = c.Int(nullable: false),
                        Position_X = c.Single(nullable: false),
                        Position_Y = c.Single(nullable: false),
                        Position_Z = c.Single(nullable: false),
                        Model = c.String(nullable: false, maxLength: 200, unicode: false),
                        WalkingStyle = c.String(nullable: false, maxLength: 200, unicode: false),
                        LastPlayed = c.DateTime(precision: 0),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Deleted = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "UserId", "dbo.Users");
            DropIndex("dbo.Characters", new[] { "UserId" });
            DropTable("dbo.Characters");
        }
    }
}
