using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class USerModelSeparate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IsElevator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsResidenceFenced",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OtherAnimalsInResidence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OwnerOfResidence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TypeOfResidence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "YardOrGardenAreaInSquareMeters",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserResidence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModelId = table.Column<int>(type: "int", nullable: false),
                    TypeOfResidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerOfResidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    IsElevator = table.Column<bool>(type: "bit", nullable: false),
                    IsResidenceFenced = table.Column<int>(type: "int", nullable: false),
                    FenceHeightInCentimeters = table.Column<int>(type: "int", nullable: false),
                    YardOrGardenAreaInSquareMeters = table.Column<int>(type: "int", nullable: false),
                    HouseholdResidents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherAnimalsInResidence = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResidence_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserResidence_UserModelId",
                table: "UserResidence",
                column: "UserModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserResidence");

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
                name: "TypeOfResidence",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YardOrGardenAreaInSquareMeters",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
