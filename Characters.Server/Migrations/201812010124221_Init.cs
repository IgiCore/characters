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
                        Forename = c.String(maxLength: 1000, unicode: false),
                        Middlename = c.String(maxLength: 1000, unicode: false),
                        Surname = c.String(maxLength: 1000, unicode: false),
                        DateOfBirth = c.DateTime(nullable: false, precision: 0),
                        Gender = c.Short(nullable: false),
                        Alive = c.Boolean(nullable: false, storeType: "bit"),
                        Health = c.Int(nullable: false),
                        Armor = c.Int(nullable: false),
                        Ssn = c.String(maxLength: 1000, unicode: false),
                        PosX = c.Single(nullable: false),
                        PosY = c.Single(nullable: false),
                        PosZ = c.Single(nullable: false),
                        Model = c.String(maxLength: 1000, unicode: false),
                        WalkingStyle = c.String(maxLength: 1000, unicode: false),
                        LastPlayed = c.DateTime(precision: 0),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Deleted = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Characters");
        }
    }
}
