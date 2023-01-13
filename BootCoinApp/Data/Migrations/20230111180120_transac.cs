using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCoinApp.Data.Migrations
{
    public partial class transac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UsersId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UsersId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UsersId",
                table: "Transactions",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UsersId",
                table: "Transactions",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
