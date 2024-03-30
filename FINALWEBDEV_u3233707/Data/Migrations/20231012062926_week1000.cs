using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FINALWEBDEV_u3233707.Data.Migrations
{
    public partial class week1000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "AddNewGenAI",
                newName: "AnchorLink");

            migrationBuilder.AddColumn<string>(
                name: "ImageFilename",
                table: "AddNewGenAI",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFilename",
                table: "AddNewGenAI");

            migrationBuilder.RenameColumn(
                name: "AnchorLink",
                table: "AddNewGenAI",
                newName: "ImagePath");
        }
    }
}
