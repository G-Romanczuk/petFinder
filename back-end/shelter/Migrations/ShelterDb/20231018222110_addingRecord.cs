using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shelter.Migrations.ShelterDb
{
    /// <inheritdoc />
    public partial class addingRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IncomeSource",
                table: "ShelterQuestionsResidence",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomeSource",
                table: "ShelterQuestionsResidence");
        }
    }
}
