using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Contacts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Contacts",
                newName: "BirthDate");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Subcategory",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Subcategory",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Contacts",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Contacts",
                newName: "DateOfBirth");
        }
    }
}
