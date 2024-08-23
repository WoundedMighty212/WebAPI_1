using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_1.Migrations
{
    /// <inheritdoc />
    public partial class Oldwayofdoingit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_UserLoginInfo_FKID",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_UserData_FKID",
                table: "UserData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserData_FKID",
                table: "UserData",
                column: "FKID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_UserLoginInfo_FKID",
                table: "UserData",
                column: "FKID",
                principalTable: "UserLoginInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
