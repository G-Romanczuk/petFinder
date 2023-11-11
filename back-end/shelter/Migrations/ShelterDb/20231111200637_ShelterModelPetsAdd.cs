using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.ShelterDb
{
    /// <inheritdoc />
    public partial class ShelterModelPetsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterModelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Castration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vaccination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildFriendly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicTraining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDogs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuddly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetModel_Shelters_ShelterModelId",
                        column: x => x.ShelterModelId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Images = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PetModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetImg_PetModel_PetModelId",
                        column: x => x.PetModelId,
                        principalTable: "PetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetImg_PetModelId",
                table: "PetImg",
                column: "PetModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PetModel_ShelterModelId",
                table: "PetModel",
                column: "ShelterModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetImg");

            migrationBuilder.DropTable(
                name: "PetModel");
        }
    }
}
