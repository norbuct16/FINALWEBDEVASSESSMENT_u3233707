using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FINALWEBDEV_u3233707.Data.Migrations
{
    public partial class finalwebdev7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLiked",
                table: "AddNewGenAI",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLiked",
                table: "AddNewGenAI");
        }
    }
}
