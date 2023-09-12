using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class AddUserResidence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResidence_Users_UserModelId",
                table: "UserResidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserResidence",
                table: "UserResidence");

            migrationBuilder.RenameTable(
                name: "UserResidence",
                newName: "Residences");

            migrationBuilder.RenameIndex(
                name: "IX_UserResidence_UserModelId",
                table: "Residences",
                newName: "IX_Residences_UserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residences",
                table: "Residences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_Users_UserModelId",
                table: "Residences",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_Users_UserModelId",
                table: "Residences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residences",
                table: "Residences");

            migrationBuilder.RenameTable(
                name: "Residences",
                newName: "UserResidence");

            migrationBuilder.RenameIndex(
                name: "IX_Residences_UserModelId",
                table: "UserResidence",
                newName: "IX_UserResidence_UserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserResidence",
                table: "UserResidence",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResidence_Users_UserModelId",
                table: "UserResidence",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
