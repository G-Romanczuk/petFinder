using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.PetDb
{
    /// <inheritdoc />
    public partial class PetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityLevel",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasBasicCommandKnowledge",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCatFriendly",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChildFriendly",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDogFriendly",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsItLikeAttention",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNeutered",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVaccinated",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Temperament",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "age",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "breed",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sex",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "HasBasicCommandKnowledge",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsCatFriendly",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsChildFriendly",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsDogFriendly",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsItLikeAttention",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsNeutered",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsVaccinated",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Temperament",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "age",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "breed",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "sex",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Pets");
        }
    }
}
