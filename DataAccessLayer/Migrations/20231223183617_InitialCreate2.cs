using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_FriendId",
                table: "Dialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_FriendId1",
                table: "Dialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FriendId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FriendId1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Users_FriendId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Users_FriendId1",
                table: "Relationships");

            migrationBuilder.DropIndex(
                name: "IX_Relationships_FriendId1",
                table: "Relationships");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FriendId1",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Dialogs_FriendId1",
                table: "Dialogs");

            migrationBuilder.DropColumn(
                name: "FriendId1",
                table: "Relationships");

            migrationBuilder.DropColumn(
                name: "FriendId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FriendId1",
                table: "Dialogs");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_UserId",
                table: "Dialogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_FriendId",
                table: "Dialogs",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_UserId",
                table: "Dialogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FriendId",
                table: "Messages",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Users_FriendId",
                table: "Relationships",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Users_UserId",
                table: "Relationships",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_FriendId",
                table: "Dialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_UserId",
                table: "Dialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FriendId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Users_FriendId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_Users_UserId",
                table: "Relationships");

            migrationBuilder.DropIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Dialogs_UserId",
                table: "Dialogs");

            migrationBuilder.AddColumn<long>(
                name: "FriendId1",
                table: "Relationships",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FriendId1",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FriendId1",
                table: "Dialogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_FriendId1",
                table: "Relationships",
                column: "FriendId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FriendId1",
                table: "Messages",
                column: "FriendId1");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_FriendId1",
                table: "Dialogs",
                column: "FriendId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_FriendId",
                table: "Dialogs",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_FriendId1",
                table: "Dialogs",
                column: "FriendId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FriendId",
                table: "Messages",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FriendId1",
                table: "Messages",
                column: "FriendId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Users_FriendId",
                table: "Relationships",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_Users_FriendId1",
                table: "Relationships",
                column: "FriendId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
