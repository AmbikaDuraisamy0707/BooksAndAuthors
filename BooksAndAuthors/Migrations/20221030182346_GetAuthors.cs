using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksAndAuthors.Migrations
{
    public partial class GetAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string procedure = @"CREATE PROCEDURE GetAuthors
                                AS
                                BEGIN
                                Select * FROM Books order by AuthorFirstName,AuthorLastName,Title
                                END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE GetAuthors";
            migrationBuilder.Sql(procedure);

        }
    }
}
