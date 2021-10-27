using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 699, DateTimeKind.Local).AddTicks(1463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 738, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "PostTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 707, DateTimeKind.Local).AddTicks(2277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 746, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.AddColumn<byte[]>(
                name: "TimeStamp",
                table: "PostTags",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 696, DateTimeKind.Local).AddTicks(7378),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 736, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 687, DateTimeKind.Local).AddTicks(3873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 727, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 712, DateTimeKind.Local).AddTicks(8147),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 746, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Id_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 710, DateTimeKind.Local).AddTicks(6590)),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodStuff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStuff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPost",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPost", x => new { x.CategoriesId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_CategoryPost_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPost_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 712, DateTimeKind.Local).AddTicks(3158)),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategory_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodStuffPost",
                columns: table => new
                {
                    FoodStuffsId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStuffPost", x => new { x.FoodStuffsId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_FoodStuffPost_FoodStuff_FoodStuffsId",
                        column: x => x.FoodStuffsId,
                        principalTable: "FoodStuff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodStuffPost_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostFoodStuff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    FoodStuffId = table.Column<int>(type: "int", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostFoodStuff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostFoodStuff_FoodStuff_FoodStuffId",
                        column: x => x.FoodStuffId,
                        principalTable: "FoodStuff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostFoodStuff_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EnTitle",
                table: "Categories",
                column: "EnTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Title",
                table: "Categories",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPost_PostsId",
                table: "CategoryPost",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodStuffPost_PostsId",
                table: "FoodStuffPost",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoryId",
                table: "PostCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostFoodStuff_FoodStuffId",
                table: "PostFoodStuff",
                column: "FoodStuffId");

            migrationBuilder.CreateIndex(
                name: "IX_PostFoodStuff_PostId",
                table: "PostFoodStuff",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPost");

            migrationBuilder.DropTable(
                name: "FoodStuffPost");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "PostFoodStuff");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FoodStuff");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "PostTags");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 738, DateTimeKind.Local).AddTicks(2620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 699, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "PostTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 746, DateTimeKind.Local).AddTicks(3211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 707, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 736, DateTimeKind.Local).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 696, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 727, DateTimeKind.Local).AddTicks(2679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 687, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 20, 17, 31, 2, 746, DateTimeKind.Local).AddTicks(8068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 2, 9, 44, 57, 712, DateTimeKind.Local).AddTicks(8147));
        }
    }
}
