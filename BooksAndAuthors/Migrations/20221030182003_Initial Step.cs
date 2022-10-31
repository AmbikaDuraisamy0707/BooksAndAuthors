using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksAndAuthors.Migrations
{
    public partial class InitialStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    JournalTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolumeNo = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMS_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MLA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    TitleOfContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleOfSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageRange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MLA_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CMS_BookId",
                table: "CMS",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MLA_BookId",
                table: "MLA",
                column: "BookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMS");

            migrationBuilder.DropTable(
                name: "MLA");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
