using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students_Mangmaent_With_Repostory_patten.Data.Migrations
{
    public partial class CreateCourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cources", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cources");
        }
    }
}
