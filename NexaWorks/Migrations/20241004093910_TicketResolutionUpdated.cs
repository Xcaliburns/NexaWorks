using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexaWorks.Migrations
{
    /// <inheritdoc />
    public partial class TicketResolutionUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResolutioDescription",
                table: "TicketResolutions",
                newName: "ResolutionDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResolutionDescription",
                table: "TicketResolutions",
                newName: "ResolutioDescription");
        }
    }
}
