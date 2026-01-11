using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalProject.Migrations
{
    /// <inheritdoc />
    public partial class AddSentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "ContactMessages",
                newName: "SentDate");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContactMessages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContactMessages");

            migrationBuilder.RenameColumn(
                name: "SentDate",
                table: "ContactMessages",
                newName: "SenderName");
        }
    }
}
