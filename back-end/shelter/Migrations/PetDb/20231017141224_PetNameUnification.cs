using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.PetDb
{
    /// <inheritdoc />
    public partial class PetNameUnification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Pets",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "breed",
                table: "Pets",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Pets",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "sex",
                table: "Pets",
                newName: "Vaccination");

            migrationBuilder.RenameColumn(
                name: "Temperament",
                table: "Pets",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Pets",
                newName: "Temper");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BasicTraining",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Castration",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChildFriendly",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cuddly",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherCats",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherDogs",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BasicTraining",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Castration",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ChildFriendly",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Cuddly",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OtherCats",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OtherDogs",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Pets",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Pets",
                newName: "breed");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Pets",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Vaccination",
                table: "Pets",
                newName: "sex");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Pets",
                newName: "Temperament");

            migrationBuilder.RenameColumn(
                name: "Temper",
                table: "Pets",
                newName: "ShortDescription");

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
        }
    }
}
