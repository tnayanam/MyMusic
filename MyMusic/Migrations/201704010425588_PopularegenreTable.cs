namespace MyMusic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopularegenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Country')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Blues')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Metal')");
        }

        public override void Down()
        {
            Sql("DROP FROM Genres WHERE Id IN (1,2,3,4");
        }
    }
}
