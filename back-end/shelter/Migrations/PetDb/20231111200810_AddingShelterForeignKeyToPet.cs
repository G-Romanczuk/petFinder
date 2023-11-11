using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.PetDb
{
    /// <inheritdoc />
    public partial class AddingShelterForeignKeyToPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShelterModelId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShelterModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShelterHabbitsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterModelId = table.Column<int>(type: "int", nullable: false),
                    Lifestyle = table.Column<bool>(type: "bit", nullable: false),
                    HoursAlone = table.Column<bool>(type: "bit", nullable: false),
                    WalksNumber = table.Column<bool>(type: "bit", nullable: false),
                    WalksTime = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterHabbitsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterHabbitsModel_ShelterModel_ShelterModelId",
                        column: x => x.ShelterModelId,
                        principalTable: "ShelterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelterPetDetailsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterModelId = table.Column<int>(type: "int", nullable: false),
                    PetPlace = table.Column<bool>(type: "bit", nullable: false),
                    PetPlaceAlone = table.Column<bool>(type: "bit", nullable: false),
                    CareAlone = table.Column<bool>(type: "bit", nullable: false),
                    AnimalsBefore = table.Column<bool>(type: "bit", nullable: false),
                    AnimalsBeforeText = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterPetDetailsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterPetDetailsModel_ShelterModel_ShelterModelId",
                        column: x => x.ShelterModelId,
                        principalTable: "ShelterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelterResidenceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterModelId = table.Column<int>(type: "int", nullable: false),
                    IncomeSource = table.Column<bool>(type: "bit", nullable: false),
                    HousingType = table.Column<bool>(type: "bit", nullable: false),
                    HouseOwner = table.Column<bool>(type: "bit", nullable: false),
                    Floor = table.Column<bool>(type: "bit", nullable: false),
                    Elevator = table.Column<bool>(type: "bit", nullable: false),
                    Fence = table.Column<bool>(type: "bit", nullable: false),
                    FenceHeight = table.Column<bool>(type: "bit", nullable: false),
                    PropertySize = table.Column<bool>(type: "bit", nullable: false),
                    HouseMates = table.Column<bool>(type: "bit", nullable: false),
                    Animals = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterResidenceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterResidenceModel_ShelterModel_ShelterModelId",
                        column: x => x.ShelterModelId,
                        principalTable: "ShelterModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ShelterModelId",
                table: "Pets",
                column: "ShelterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterHabbitsModel_ShelterModelId",
                table: "ShelterHabbitsModel",
                column: "ShelterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterPetDetailsModel_ShelterModelId",
                table: "ShelterPetDetailsModel",
                column: "ShelterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterResidenceModel_ShelterModelId",
                table: "ShelterResidenceModel",
                column: "ShelterModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_ShelterModel_ShelterModelId",
                table: "Pets",
                column: "ShelterModelId",
                principalTable: "ShelterModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_ShelterModel_ShelterModelId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "ShelterHabbitsModel");

            migrationBuilder.DropTable(
                name: "ShelterPetDetailsModel");

            migrationBuilder.DropTable(
                name: "ShelterResidenceModel");

            migrationBuilder.DropTable(
                name: "ShelterModel");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ShelterModelId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ShelterModelId",
                table: "Pets");
        }
    }
}
