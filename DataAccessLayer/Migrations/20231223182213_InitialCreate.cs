using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Login = table.Column<string>(type: "varchar(32)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dialogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dialogs_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dialogs_Users_FriendId1",
                        column: x => x.FriendId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId1 = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Relationships_Users_FriendId1",
                        column: x => x.FriendId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId1 = table.Column<long>(type: "bigint", nullable: false),
                    DialogId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Dialogs_DialogId",
                        column: x => x.DialogId,
                        principalTable: "Dialogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_FriendId1",
                        column: x => x.FriendId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_FriendId",
                table: "Dialogs",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_FriendId1",
                table: "Dialogs",
                column: "FriendId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DialogId",
                table: "Messages",
                column: "DialogId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FriendId",
                table: "Messages",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FriendId1",
                table: "Messages",
                column: "FriendId1");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_FriendId",
                table: "Relationships",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_FriendId1",
                table: "Relationships",
                column: "FriendId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Dialogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
