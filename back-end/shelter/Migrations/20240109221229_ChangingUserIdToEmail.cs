using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class ChangingUserIdToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PetLike");

            migrationBuilder.AddColumn<string>(
                name: "userEmail",
                table: "PetLike",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userEmail",
                table: "PetLike");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PetLike",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
