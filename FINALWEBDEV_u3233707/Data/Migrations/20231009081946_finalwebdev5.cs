using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FINALWEBDEV_u3233707.Data.Migrations
{
    public partial class finalwebdev5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "AddNewGenAI",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "AddNewGenAI");
        }
    }
}
