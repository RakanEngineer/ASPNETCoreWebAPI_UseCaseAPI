using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCoreWebAPI_CQRS.Migrations
{
    /// <inheritdoc />
    public partial class AddChangePriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Tickets",
                newName: "CommentsJson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentsJson",
                table: "Tickets",
                newName: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
