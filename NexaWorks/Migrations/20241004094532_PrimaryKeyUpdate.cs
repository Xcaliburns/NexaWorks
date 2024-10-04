using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexaWorks.Migrations
{
    /// <inheritdoc />
    public partial class PrimaryKeyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersionOperatingSystems_OperatingSystems_OperatingSystemId",
                table: "ProductVersionOperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersionOperatingSystems_Products_ProductId",
                table: "ProductVersionOperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersionOperatingSystems_Versions_VersionId",
                table: "ProductVersionOperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProductVersionOperatingSystems_ProductVersionOperatingSystemId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersionOperatingSystems_OperatingSystems_OperatingSystemId",
                table: "ProductVersionOperatingSystems",
                column: "OperatingSystemId",
                principalTable: "OperatingSystems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersionOperatingSystems_Products_ProductId",
                table: "ProductVersionOperatingSystems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersionOperatingSystems_Versions_VersionId",
                table: "ProductVersionOperatingSystems",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProductVersionOperatingSystems_ProductVersionOperatingSystemId",
                table: "Tickets",
                column: "ProductVersionOperatingSystemId",
                principalTable: "ProductVersionOperatingSystems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersionOperatingSystems_OperatingSystems_OperatingSystemId",
                table: "ProductVersionOperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersionOperatingSystems_Products_ProductId",
                table: "ProductVersionOperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVersionOperatingSystems_Versions_VersionId",
                table: "ProductVersionOperatingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProductVersionOperatingSystems_ProductVersionOperatingSystemId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersionOperatingSystems_OperatingSystems_OperatingSystemId",
                table: "ProductVersionOperatingSystems",
                column: "OperatingSystemId",
                principalTable: "OperatingSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersionOperatingSystems_Products_ProductId",
                table: "ProductVersionOperatingSystems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVersionOperatingSystems_Versions_VersionId",
                table: "ProductVersionOperatingSystems",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProductVersionOperatingSystems_ProductVersionOperatingSystemId",
                table: "Tickets",
                column: "ProductVersionOperatingSystemId",
                principalTable: "ProductVersionOperatingSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
