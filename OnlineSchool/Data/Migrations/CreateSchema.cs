using FluentMigrator;

namespace OnlineSchool.Data.Migrations
{
    [Migration(13442)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {

            Create.Table("students")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Age").AsInt32().NotNullable();


            Create.Table("books")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdStudent").AsInt32().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Created").AsDate().NotNullable();


        }
        public override void Down()
        {
           
        }


    }
}
