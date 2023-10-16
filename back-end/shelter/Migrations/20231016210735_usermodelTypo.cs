using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class usermodelTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Adress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Users",
                newName: "Address");
        }
    }
}
