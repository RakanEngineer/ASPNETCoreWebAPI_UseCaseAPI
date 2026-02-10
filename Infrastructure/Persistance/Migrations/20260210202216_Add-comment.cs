using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCoreWebAPI_CQRS.Migrations
{
    /// <inheritdoc />
    public partial class Addcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Tickets");
        }
    }
}
