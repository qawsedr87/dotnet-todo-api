using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoBackend.Migrations
{
    /// <inheritdoc />
    public partial class SetupManyToManyInTaskAndTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tag_task_TaskId",
                table: "tag");

            migrationBuilder.DropIndex(
                name: "IX_tag_TaskId",
                table: "tag");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "tag");

            migrationBuilder.CreateTable(
                name: "TagTask",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "integer", nullable: false),
                    TasksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTask", x => new { x.TagsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_TagTask_tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTask_task_TasksId",
                        column: x => x.TasksId,
                        principalTable: "task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTask_TasksId",
                table: "TagTask",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTask");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "tag",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tag_TaskId",
                table: "tag",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_tag_task_TaskId",
                table: "tag",
                column: "TaskId",
                principalTable: "task",
                principalColumn: "Id");
        }
    }
}
