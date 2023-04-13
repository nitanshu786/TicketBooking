using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations
{
    public partial class removetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_TicketTables_TicketId",
                table: "UserTables");

            migrationBuilder.DropIndex(
                name: "IX_UserTables_TicketId",
                table: "UserTables");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "UserTables");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserTables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserTables");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "UserTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_TicketId",
                table: "UserTables",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_TicketTables_TicketId",
                table: "UserTables",
                column: "TicketId",
                principalTable: "TicketTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
