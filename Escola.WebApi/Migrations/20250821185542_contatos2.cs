using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Api.Migrations
{
    /// <inheritdoc />
    public partial class contatos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contato",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contato",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");
        }
    }
}
