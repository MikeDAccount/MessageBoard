using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class UpdatedComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meesages_Messages_MessageId",
                table: "Meesages");

            migrationBuilder.DropForeignKey(
                name: "FK_Meesages_User_UserId",
                table: "Meesages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meesages",
                table: "Meesages");

            migrationBuilder.RenameTable(
                name: "Meesages",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Meesages_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meesages_MessageId",
                table: "Comments",
                newName: "IX_Comments_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Messages_MessageId",
                table: "Comments",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Messages_MessageId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Meesages");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Meesages",
                newName: "IX_Meesages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MessageId",
                table: "Meesages",
                newName: "IX_Meesages_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meesages",
                table: "Meesages",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meesages_Messages_MessageId",
                table: "Meesages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meesages_User_UserId",
                table: "Meesages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
