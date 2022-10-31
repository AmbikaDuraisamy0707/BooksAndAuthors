using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksAndAuthors.Migrations
{
    public partial class GetBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string procedure = @"CREATE PROCEDURE GetBooks
                                AS
                                BEGIN
                                Select * FROM Books order by Publisher,AuthorFirstName,AuthorLastName,Title
                                END";

            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string procedure = @"DROP PROCEDURE GetBooks";
            migrationBuilder.Sql(procedure);
        }
    }
}
