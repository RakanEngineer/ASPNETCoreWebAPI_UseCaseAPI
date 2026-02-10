using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCoreWebAPI_CQRS.Migrations
{
    /// <inheritdoc />
    public partial class AddIsEscalated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEscalated",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEscalated",
                table: "Tickets");
        }
    }
}
