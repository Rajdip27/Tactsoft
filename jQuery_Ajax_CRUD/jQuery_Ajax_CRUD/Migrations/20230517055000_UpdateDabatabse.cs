using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jQuery_Ajax_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDabatabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionModels",
                table: "TransactionModels");

            migrationBuilder.RenameTable(
                name: "TransactionModels",
                newName: "Transactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "TransactionModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionModels",
                table: "TransactionModels",
                column: "TransactionId");
        }
    }
}
