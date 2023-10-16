using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class UserSchemaNamesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeWhenOwnedDog",
                table: "usersDogDetails",
                newName: "PetPlaceAlone");

            migrationBuilder.RenameColumn(
                name: "PastDogsHistory",
                table: "usersDogDetails",
                newName: "PetPlace");

            migrationBuilder.RenameColumn(
                name: "DogLocationThroughoutDay",
                table: "usersDogDetails",
                newName: "AnimalsBeforeText");

            migrationBuilder.RenameColumn(
                name: "DogLocationDuringOwnerAndOthersAbsence",
                table: "usersDogDetails",
                newName: "AnimalsBefore");

            migrationBuilder.RenameColumn(
                name: "CanProvideSubstituteCareDuringExtendedAbsence",
                table: "usersDogDetails",
                newName: "CareAlone");

            migrationBuilder.RenameColumn(
                name: "terms",
                table: "Users",
                newName: "Terms");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "Town");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "Lname");

            migrationBuilder.RenameColumn(
                name: "YardOrGardenAreaInSquareMeters",
                table: "Residences",
                newName: "PropertySize");

            migrationBuilder.RenameColumn(
                name: "TypeOfResidence",
                table: "Residences",
                newName: "HousingType");

            migrationBuilder.RenameColumn(
                name: "OwnerOfResidence",
                table: "Residences",
                newName: "HouseOwner");

            migrationBuilder.RenameColumn(
                name: "OtherAnimalsInResidence",
                table: "Residences",
                newName: "HouseMates");

            migrationBuilder.RenameColumn(
                name: "IsResidenceFenced",
                table: "Residences",
                newName: "IsFence");

            migrationBuilder.RenameColumn(
                name: "HouseholdResidents",
                table: "Residences",
                newName: "Animals");

            migrationBuilder.RenameColumn(
                name: "FloorNumber",
                table: "Residences",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "FenceHeightInCentimeters",
                table: "Residences",
                newName: "FenceHeight");

            migrationBuilder.RenameColumn(
                name: "WalksPerDay",
                table: "Habbits",
                newName: "WalksTime");

            migrationBuilder.RenameColumn(
                name: "UserStoryLine",
                table: "Habbits",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "MaxHoursAway",
                table: "Habbits",
                newName: "WalksNumber");

            migrationBuilder.RenameColumn(
                name: "LongestWalkDurationMinutes",
                table: "Habbits",
                newName: "HoursAlone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetPlaceAlone",
                table: "usersDogDetails",
                newName: "TimeWhenOwnedDog");

            migrationBuilder.RenameColumn(
                name: "PetPlace",
                table: "usersDogDetails",
                newName: "PastDogsHistory");

            migrationBuilder.RenameColumn(
                name: "CareAlone",
                table: "usersDogDetails",
                newName: "CanProvideSubstituteCareDuringExtendedAbsence");

            migrationBuilder.RenameColumn(
                name: "AnimalsBeforeText",
                table: "usersDogDetails",
                newName: "DogLocationThroughoutDay");

            migrationBuilder.RenameColumn(
                name: "AnimalsBefore",
                table: "usersDogDetails",
                newName: "DogLocationDuringOwnerAndOthersAbsence");

            migrationBuilder.RenameColumn(
                name: "Terms",
                table: "Users",
                newName: "terms");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Lname",
                table: "Users",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "PropertySize",
                table: "Residences",
                newName: "YardOrGardenAreaInSquareMeters");

            migrationBuilder.RenameColumn(
                name: "IsFence",
                table: "Residences",
                newName: "IsResidenceFenced");

            migrationBuilder.RenameColumn(
                name: "HousingType",
                table: "Residences",
                newName: "TypeOfResidence");

            migrationBuilder.RenameColumn(
                name: "HouseOwner",
                table: "Residences",
                newName: "OwnerOfResidence");

            migrationBuilder.RenameColumn(
                name: "HouseMates",
                table: "Residences",
                newName: "OtherAnimalsInResidence");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Residences",
                newName: "FloorNumber");

            migrationBuilder.RenameColumn(
                name: "FenceHeight",
                table: "Residences",
                newName: "FenceHeightInCentimeters");

            migrationBuilder.RenameColumn(
                name: "Animals",
                table: "Residences",
                newName: "HouseholdResidents");

            migrationBuilder.RenameColumn(
                name: "WalksTime",
                table: "Habbits",
                newName: "WalksPerDay");

            migrationBuilder.RenameColumn(
                name: "WalksNumber",
                table: "Habbits",
                newName: "MaxHoursAway");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Habbits",
                newName: "UserStoryLine");

            migrationBuilder.RenameColumn(
                name: "HoursAlone",
                table: "Habbits",
                newName: "LongestWalkDurationMinutes");
        }
    }
}
