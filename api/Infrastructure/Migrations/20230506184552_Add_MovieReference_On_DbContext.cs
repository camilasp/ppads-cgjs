using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_MovieReference_On_DbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieReferences_Users_UserId",
                table: "MovieReferences");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieReferences_Users_UserId",
                table: "MovieReferences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieReferences_Users_UserId",
                table: "MovieReferences");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieReferences_Users_UserId",
                table: "MovieReferences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
