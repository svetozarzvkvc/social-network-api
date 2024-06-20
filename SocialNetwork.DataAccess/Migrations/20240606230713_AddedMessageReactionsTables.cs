using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedMessageReactionsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupChatMessageReactions",
                columns: table => new
                {
                    ReacitonId = table.Column<int>(type: "int", nullable: false),
                    GroupChatMessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReactedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ReactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatMessageReactions", x => new { x.GroupChatMessageId, x.ReacitonId });
                    table.ForeignKey(
                        name: "FK_GroupChatMessageReactions_GroupChatMessage_GroupChatMessageId",
                        column: x => x.GroupChatMessageId,
                        principalTable: "GroupChatMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupChatMessageReactions_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupChatMessageReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrivateMessageReactions",
                columns: table => new
                {
                    ReacitonId = table.Column<int>(type: "int", nullable: false),
                    PrivateMessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReactedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ReactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessageReactions", x => new { x.PrivateMessageId, x.ReacitonId });
                    table.ForeignKey(
                        name: "FK_PrivateMessageReactions_PrivateMessages_PrivateMessageId",
                        column: x => x.PrivateMessageId,
                        principalTable: "PrivateMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivateMessageReactions_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateMessageReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessageReactions_ReactionId",
                table: "GroupChatMessageReactions",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessageReactions_UserId",
                table: "GroupChatMessageReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessageReactions_ReactionId",
                table: "PrivateMessageReactions",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessageReactions_UserId",
                table: "PrivateMessageReactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupChatMessageReactions");

            migrationBuilder.DropTable(
                name: "PrivateMessageReactions");
        }
    }
}
