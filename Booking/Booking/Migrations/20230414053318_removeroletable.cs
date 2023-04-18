using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations
{
    public partial class removeroletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTables_RoleTables_RoleTableId",
                table: "UserTables");

            migrationBuilder.DropTable(
                name: "RoleTables");

            migrationBuilder.DropIndex(
                name: "IX_UserTables_RoleTableId",
                table: "UserTables");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserTables");

            migrationBuilder.DropColumn(
                name: "RoleTableId",
                table: "UserTables");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserTables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserTables");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleTableId",
                table: "UserTables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTables", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTables_RoleTableId",
                table: "UserTables",
                column: "RoleTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTables_RoleTables_RoleTableId",
                table: "UserTables",
                column: "RoleTableId",
                principalTable: "RoleTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
