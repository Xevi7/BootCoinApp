using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCoinApp.Data.Migrations
{
    public partial class addFullNameUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "AspNetUsers",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Picture");
        }
    }
}
