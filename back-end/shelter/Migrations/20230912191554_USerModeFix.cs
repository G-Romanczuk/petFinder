using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class USerModeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CanProvideSubstituteCareDuringExtendedAbsence",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DogLocationDuringOwnerAndOthersAbsence",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DogWhereaboutsThroughoutDay",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FenceHeightInCentimeters",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HouseholdResidents",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncomeSource",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsElevator",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IsResidenceFenced",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Lifestyle",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LongestWalkDurationMinutes",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHoursAway",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OtherAnimalsInResidence",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerOfResidence",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PastDogsHistory",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeWhenOwnedDog",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfResidence",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserStoryLine",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WalksPerDay",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YardOrGardenAreaInSquareMeters",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CanProvideSubstituteCareDuringExtendedAbsence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DogLocationDuringOwnerAndOthersAbsence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DogWhereaboutsThroughoutDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FenceHeightInCentimeters",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HouseholdResidents",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IncomeSource",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsElevator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsResidenceFenced",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lifestyle",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LongestWalkDurationMinutes",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MaxHoursAway",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OtherAnimalsInResidence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OwnerOfResidence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PastDogsHistory",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimeWhenOwnedDog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeOfResidence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserStoryLine",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WalksPerDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "YardOrGardenAreaInSquareMeters",
                table: "Users");
        }
    }
}
