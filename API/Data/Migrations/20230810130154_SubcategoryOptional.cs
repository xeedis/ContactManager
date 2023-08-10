using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubcategoryOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Subcategory_SubcategoryId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_SubcategoryId",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "Category",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SubcategoryId",
                table: "Category",
                column: "SubcategoryId",
                unique: true,
                filter: "[SubcategoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Subcategory_SubcategoryId",
                table: "Category",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Subcategory_SubcategoryId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_SubcategoryId",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoryId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_SubcategoryId",
                table: "Category",
                column: "SubcategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Subcategory_SubcategoryId",
                table: "Category",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
