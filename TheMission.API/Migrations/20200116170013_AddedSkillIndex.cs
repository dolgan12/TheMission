using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMission.API.Migrations
{
    public partial class AddedSkillIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillName",
                table: "Skills",
                column: "SkillName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillName",
                table: "Skills");
        }
    }
}
