using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Subcategory",
                table: "Contacts",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubcategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SubcategoryId",
                table: "Category",
                column: "SubcategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Category_CategoryId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Contacts",
                newName: "Subcategory");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
