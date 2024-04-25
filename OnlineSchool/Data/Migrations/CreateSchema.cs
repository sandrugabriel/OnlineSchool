using FluentMigrator;

namespace OnlineSchool.Data.Migrations
{
    [Migration(1342)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("students")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("age").AsInt32().NotNullable();

            Create.Table("books")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("idStudent").AsInt32().NotNullable()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("created").AsDate().NotNullable();


        }
        public override void Down()
        {
           
        }


    }
}
