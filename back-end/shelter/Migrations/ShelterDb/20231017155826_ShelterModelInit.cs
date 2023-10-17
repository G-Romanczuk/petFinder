using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.ShelterDb
{
    /// <inheritdoc />
    public partial class ShelterModelInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Shelters",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Shelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailShelter",
                table: "Shelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Shelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Shelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Shelters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ShelterQuestionsHabbits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterModelId = table.Column<int>(type: "int", nullable: false),
                    Lifestyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursAlone = table.Column<int>(type: "int", nullable: false),
                    WalksNumber = table.Column<int>(type: "int", nullable: false),
                    WalksTime = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterQuestionsHabbits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterQuestionsHabbits_Shelters_ShelterModelId",
                        column: x => x.ShelterModelId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelterQuestionsPetDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterModelId = table.Column<int>(type: "int", nullable: false),
                    PetPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetPlaceAlone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareAlone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalsBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalsBeforeText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterQuestionsPetDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterQuestionsPetDetails_Shelters_ShelterModelId",
                        column: x => x.ShelterModelId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelterQuestionsResidence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterModelId = table.Column<int>(type: "int", nullable: false),
                    HousingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Elevator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FenceHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertySize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseMates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Animals = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterQuestionsResidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterQuestionsResidence_Shelters_ShelterModelId",
                        column: x => x.ShelterModelId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelterQuestionsHabbits_ShelterModelId",
                table: "ShelterQuestionsHabbits",
                column: "ShelterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterQuestionsPetDetails_ShelterModelId",
                table: "ShelterQuestionsPetDetails",
                column: "ShelterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterQuestionsResidence_ShelterModelId",
                table: "ShelterQuestionsResidence",
                column: "ShelterModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShelterQuestionsHabbits");

            migrationBuilder.DropTable(
                name: "ShelterQuestionsPetDetails");

            migrationBuilder.DropTable(
                name: "ShelterQuestionsResidence");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "EmailShelter",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Shelters");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Shelters",
                newName: "Email");
        }
    }
}
