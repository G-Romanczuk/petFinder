using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class newModelClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanProvideSubstituteCareDuringExtendedAbsence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DogLocationDuringOwnerAndOthersAbsence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DogWhereaboutsThroughoutDay",
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
                name: "PastDogsHistory",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimeWhenOwnedDog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserStoryLine",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WalksPerDay",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Habbits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModelId = table.Column<int>(type: "int", nullable: false),
                    Lifestyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHoursAway = table.Column<int>(type: "int", nullable: false),
                    WalksPerDay = table.Column<int>(type: "int", nullable: false),
                    LongestWalkDurationMinutes = table.Column<int>(type: "int", nullable: false),
                    UserStoryLine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habbits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habbits_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usersDogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModelId = table.Column<int>(type: "int", nullable: false),
                    DogLocationThroughoutDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogLocationDuringOwnerAndOthersAbsence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanProvideSubstituteCareDuringExtendedAbsence = table.Column<bool>(type: "bit", nullable: false),
                    TimeWhenOwnedDog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PastDogsHistory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersDogDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usersDogDetails_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habbits_UserModelId",
                table: "Habbits",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_usersDogDetails_UserModelId",
                table: "usersDogDetails",
                column: "UserModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habbits");

            migrationBuilder.DropTable(
                name: "usersDogDetails");

            migrationBuilder.AddColumn<bool>(
                name: "CanProvideSubstituteCareDuringExtendedAbsence",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "PastDogsHistory",
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
        }
    }
}
