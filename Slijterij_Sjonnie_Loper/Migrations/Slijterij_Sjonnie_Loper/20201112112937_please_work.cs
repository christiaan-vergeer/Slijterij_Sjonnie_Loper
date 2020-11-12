using Microsoft.EntityFrameworkCore.Migrations;

namespace Slijterij_Sjonnie_Loper.Migrations.Slijterij_Sjonnie_Loper
{
    public partial class please_work : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullname",
                table: "AspNetUsers");
        }
    }
}
