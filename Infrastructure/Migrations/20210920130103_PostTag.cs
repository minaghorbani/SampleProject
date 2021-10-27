using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class PostTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 736, DateTimeKind.Local).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 19, 9, 3, 20, 733, DateTimeKind.Local).AddTicks(8543));

            migrationBuilder.AlterColumn<string>(
                name: "EnDescription",
                table: "Blogs",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 727, DateTimeKind.Local).AddTicks(2679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 19, 9, 3, 20, 723, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 746, DateTimeKind.Local).AddTicks(8068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 19, 9, 3, 20, 734, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Id_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 738, DateTimeKind.Local).AddTicks(2620)),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 746, DateTimeKind.Local).AddTicks(3211))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Title",
                table: "Tags",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 19, 9, 3, 20, 733, DateTimeKind.Local).AddTicks(8543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 736, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.AlterColumn<string>(
                name: "EnDescription",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 19, 9, 3, 20, 723, DateTimeKind.Local).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 727, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 19, 9, 3, 20, 734, DateTimeKind.Local).AddTicks(3730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 746, DateTimeKind.Local).AddTicks(8068));
        }
    }
}
