using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.PetDb
{
    /// <inheritdoc />
    public partial class expelPetImgFromMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "PetImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Images = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PetModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetImgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetImgs_Pets_PetModelId",
                        column: x => x.PetModelId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetImgs_PetModelId",
                table: "PetImgs",
                column: "PetModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetImgs");

            migrationBuilder.AddColumn<byte[]>(
                name: "Images",
                table: "Pets",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
