using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dencove_API.Migrations
{
    /// <inheritdoc />
    public partial class initial_demcove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BairroModels",
                table: "BairroModels");

            migrationBuilder.RenameTable(
                name: "BairroModels",
                newName: "Bairro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bairro",
                table: "Bairro",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bairro",
                table: "Bairro");

            migrationBuilder.RenameTable(
                name: "Bairro",
                newName: "BairroModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BairroModels",
                table: "BairroModels",
                column: "Id");
        }
    }
}
