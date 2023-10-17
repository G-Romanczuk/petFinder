using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.ShelterDb
{
    /// <inheritdoc />
    public partial class fixingtypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailShelter",
                table: "Shelters",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Shelters",
                newName: "EmailShelter");
        }
    }
}
