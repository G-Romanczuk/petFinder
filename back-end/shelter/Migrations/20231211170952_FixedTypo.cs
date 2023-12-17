using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habbits_RegisteredUsers_UserModelId",
                table: "Habbits");

            migrationBuilder.DropForeignKey(
                name: "FK_Residences_RegisteredUsers_UserModelId",
                table: "Residences");

            migrationBuilder.DropForeignKey(
                name: "FK_usersDogDetails_RegisteredUsers_UserModelId",
                table: "usersDogDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usersDogDetails",
                table: "usersDogDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residences",
                table: "Residences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisteredUsers",
                table: "RegisteredUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habbits",
                table: "Habbits");

            migrationBuilder.RenameTable(
                name: "usersDogDetails",
                newName: "UserQuestionsPetDetails");

            migrationBuilder.RenameTable(
                name: "Residences",
                newName: "UserQuestionsResidence");

            migrationBuilder.RenameTable(
                name: "RegisteredUsers",
                newName: "UsersRegistered");

            migrationBuilder.RenameTable(
                name: "Habbits",
                newName: "UserQuestionsHabbits");

            migrationBuilder.RenameIndex(
                name: "IX_usersDogDetails_UserModelId",
                table: "UserQuestionsPetDetails",
                newName: "IX_UserQuestionsPetDetails_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Residences_UserModelId",
                table: "UserQuestionsResidence",
                newName: "IX_UserQuestionsResidence_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Habbits_UserModelId",
                table: "UserQuestionsHabbits",
                newName: "IX_UserQuestionsHabbits_UserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuestionsPetDetails",
                table: "UserQuestionsPetDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuestionsResidence",
                table: "UserQuestionsResidence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRegistered",
                table: "UsersRegistered",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuestionsHabbits",
                table: "UserQuestionsHabbits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionsHabbits_UsersRegistered_UserModelId",
                table: "UserQuestionsHabbits",
                column: "UserModelId",
                principalTable: "UsersRegistered",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionsPetDetails_UsersRegistered_UserModelId",
                table: "UserQuestionsPetDetails",
                column: "UserModelId",
                principalTable: "UsersRegistered",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionsResidence_UsersRegistered_UserModelId",
                table: "UserQuestionsResidence",
                column: "UserModelId",
                principalTable: "UsersRegistered",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionsHabbits_UsersRegistered_UserModelId",
                table: "UserQuestionsHabbits");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionsPetDetails_UsersRegistered_UserModelId",
                table: "UserQuestionsPetDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionsResidence_UsersRegistered_UserModelId",
                table: "UserQuestionsResidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRegistered",
                table: "UsersRegistered");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuestionsResidence",
                table: "UserQuestionsResidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuestionsPetDetails",
                table: "UserQuestionsPetDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuestionsHabbits",
                table: "UserQuestionsHabbits");

            migrationBuilder.RenameTable(
                name: "UsersRegistered",
                newName: "RegisteredUsers");

            migrationBuilder.RenameTable(
                name: "UserQuestionsResidence",
                newName: "Residences");

            migrationBuilder.RenameTable(
                name: "UserQuestionsPetDetails",
                newName: "usersDogDetails");

            migrationBuilder.RenameTable(
                name: "UserQuestionsHabbits",
                newName: "Habbits");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestionsResidence_UserModelId",
                table: "Residences",
                newName: "IX_Residences_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestionsPetDetails_UserModelId",
                table: "usersDogDetails",
                newName: "IX_usersDogDetails_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuestionsHabbits_UserModelId",
                table: "Habbits",
                newName: "IX_Habbits_UserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisteredUsers",
                table: "RegisteredUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residences",
                table: "Residences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usersDogDetails",
                table: "usersDogDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habbits",
                table: "Habbits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habbits_RegisteredUsers_UserModelId",
                table: "Habbits",
                column: "UserModelId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_RegisteredUsers_UserModelId",
                table: "Residences",
                column: "UserModelId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usersDogDetails_RegisteredUsers_UserModelId",
                table: "usersDogDetails",
                column: "UserModelId",
                principalTable: "RegisteredUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
