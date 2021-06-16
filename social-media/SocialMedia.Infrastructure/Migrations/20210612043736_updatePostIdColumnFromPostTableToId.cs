using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMedia.Infrastructure.Migrations
{
    public partial class updatePostIdColumnFromPostTableToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostUser_Posts_PostsPostId",
                table: "PostUser");

            migrationBuilder.RenameColumn(
                name: "PostsPostId",
                table: "PostUser",
                newName: "PostsId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostUser_Posts_PostsId",
                table: "PostUser",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostUser_Posts_PostsId",
                table: "PostUser");

            migrationBuilder.RenameColumn(
                name: "PostsId",
                table: "PostUser",
                newName: "PostsPostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostUser_Posts_PostsPostId",
                table: "PostUser",
                column: "PostsPostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
