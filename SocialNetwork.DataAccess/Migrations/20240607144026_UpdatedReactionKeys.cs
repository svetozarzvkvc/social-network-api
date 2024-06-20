using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedReactionKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessageReactions_Reactions_ReactionId",
                table: "GroupChatMessageReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessageReactions_Reactions_ReactionId",
                table: "PrivateMessageReactions");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessageReactions_ReactionId",
                table: "PrivateMessageReactions");

            migrationBuilder.DropIndex(
                name: "IX_GroupChatMessageReactions_ReactionId",
                table: "GroupChatMessageReactions");

            migrationBuilder.DropColumn(
                name: "ReactionId",
                table: "PrivateMessageReactions");

            migrationBuilder.DropColumn(
                name: "ReactionId",
                table: "GroupChatMessageReactions");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessageReactions_ReacitonId",
                table: "PrivateMessageReactions",
                column: "ReacitonId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessageReactions_ReacitonId",
                table: "GroupChatMessageReactions",
                column: "ReacitonId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatMessageReactions_Reactions_ReacitonId",
                table: "GroupChatMessageReactions",
                column: "ReacitonId",
                principalTable: "Reactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessageReactions_Reactions_ReacitonId",
                table: "PrivateMessageReactions",
                column: "ReacitonId",
                principalTable: "Reactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessageReactions_Reactions_ReacitonId",
                table: "GroupChatMessageReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessageReactions_Reactions_ReacitonId",
                table: "PrivateMessageReactions");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessageReactions_ReacitonId",
                table: "PrivateMessageReactions");

            migrationBuilder.DropIndex(
                name: "IX_GroupChatMessageReactions_ReacitonId",
                table: "GroupChatMessageReactions");

            migrationBuilder.AddColumn<int>(
                name: "ReactionId",
                table: "PrivateMessageReactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReactionId",
                table: "GroupChatMessageReactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessageReactions_ReactionId",
                table: "PrivateMessageReactions",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessageReactions_ReactionId",
                table: "GroupChatMessageReactions",
                column: "ReactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatMessageReactions_Reactions_ReactionId",
                table: "GroupChatMessageReactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessageReactions_Reactions_ReactionId",
                table: "PrivateMessageReactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id");
        }
    }
}
