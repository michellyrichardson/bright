using Microsoft.EntityFrameworkCore.Migrations;

namespace Bright.Migrations
{
    public partial class WhyIsItDoingThis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIdea_Ideas_IdeaId",
                table: "UserIdea");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIdea_Users_UserId",
                table: "UserIdea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIdea",
                table: "UserIdea");

            migrationBuilder.RenameTable(
                name: "UserIdea",
                newName: "UserIdeas");

            migrationBuilder.RenameIndex(
                name: "IX_UserIdea_UserId",
                table: "UserIdeas",
                newName: "IX_UserIdeas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserIdea_IdeaId",
                table: "UserIdeas",
                newName: "IX_UserIdeas_IdeaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIdeas",
                table: "UserIdeas",
                column: "UserIdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIdeas_Ideas_IdeaId",
                table: "UserIdeas",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "IdeaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIdeas_Users_UserId",
                table: "UserIdeas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIdeas_Ideas_IdeaId",
                table: "UserIdeas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIdeas_Users_UserId",
                table: "UserIdeas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIdeas",
                table: "UserIdeas");

            migrationBuilder.RenameTable(
                name: "UserIdeas",
                newName: "UserIdea");

            migrationBuilder.RenameIndex(
                name: "IX_UserIdeas_UserId",
                table: "UserIdea",
                newName: "IX_UserIdea_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserIdeas_IdeaId",
                table: "UserIdea",
                newName: "IX_UserIdea_IdeaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIdea",
                table: "UserIdea",
                column: "UserIdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIdea_Ideas_IdeaId",
                table: "UserIdea",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "IdeaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIdea_Users_UserId",
                table: "UserIdea",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
