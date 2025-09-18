using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaMedica.Data.Migrations
{
    /// <inheritdoc />
    public partial class Cidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Pacientes");
        }
    }
}
