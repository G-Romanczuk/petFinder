using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations
{
    /// <inheritdoc />
    public partial class UserFormChangingTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsElevator",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "IsFence",
                table: "Residences");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Users",
                newName: "PostCode");

            migrationBuilder.AlterColumn<string>(
                name: "CareAlone",
                table: "usersDogDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "PropertySize",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FenceHeight",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Elevator",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fence",
                table: "Residences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elevator",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "Fence",
                table: "Residences");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Users",
                newName: "PostalCode");

            migrationBuilder.AlterColumn<bool>(
                name: "CareAlone",
                table: "usersDogDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PropertySize",
                table: "Residences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "Residences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FenceHeight",
                table: "Residences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsElevator",
                table: "Residences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IsFence",
                table: "Residences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
