using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FINALWEBDEV_u3233707.Data.Migrations
{
    public partial class finalwebdev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AddNewGenAI",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AddNewGenAI");
        }
    }
}
