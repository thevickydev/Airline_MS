using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARS.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_AeroPlaneInfo_PlaneInfoPlaneId",
                table: "FlightBookTable");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_TicketReserve_tbl_TicketReserve_tblsResId",
                table: "FlightBookTable");

            migrationBuilder.DropIndex(
                name: "IX_FlightBookTable_PlaneInfoPlaneId",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "PlaneInfoPlaneId",
                table: "FlightBookTable");

            migrationBuilder.RenameColumn(
                name: "TicketReserve_tblsResId",
                table: "FlightBookTable",
                newName: "TicketReserve_tblResId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightBookTable_TicketReserve_tblsResId",
                table: "FlightBookTable",
                newName: "IX_FlightBookTable_TicketReserve_tblResId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookTable_Planeid",
                table: "FlightBookTable",
                column: "Planeid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookTable_ResId",
                table: "FlightBookTable",
                column: "ResId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookTable_AeroPlaneInfo_Planeid",
                table: "FlightBookTable",
                column: "Planeid",
                principalTable: "AeroPlaneInfo",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookTable_TicketReserve_tbl_ResId",
                table: "FlightBookTable",
                column: "ResId",
                principalTable: "TicketReserve_tbl",
                principalColumn: "ResId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookTable_TicketReserve_tbl_TicketReserve_tblResId",
                table: "FlightBookTable",
                column: "TicketReserve_tblResId",
                principalTable: "TicketReserve_tbl",
                principalColumn: "ResId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_AeroPlaneInfo_Planeid",
                table: "FlightBookTable");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_TicketReserve_tbl_ResId",
                table: "FlightBookTable");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_TicketReserve_tbl_TicketReserve_tblResId",
                table: "FlightBookTable");

            migrationBuilder.DropIndex(
                name: "IX_FlightBookTable_Planeid",
                table: "FlightBookTable");

            migrationBuilder.DropIndex(
                name: "IX_FlightBookTable_ResId",
                table: "FlightBookTable");

            migrationBuilder.RenameColumn(
                name: "TicketReserve_tblResId",
                table: "FlightBookTable",
                newName: "TicketReserve_tblsResId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightBookTable_TicketReserve_tblResId",
                table: "FlightBookTable",
                newName: "IX_FlightBookTable_TicketReserve_tblsResId");

            migrationBuilder.AddColumn<int>(
                name: "PlaneInfoPlaneId",
                table: "FlightBookTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookTable_PlaneInfoPlaneId",
                table: "FlightBookTable",
                column: "PlaneInfoPlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookTable_AeroPlaneInfo_PlaneInfoPlaneId",
                table: "FlightBookTable",
                column: "PlaneInfoPlaneId",
                principalTable: "AeroPlaneInfo",
                principalColumn: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookTable_TicketReserve_tbl_TicketReserve_tblsResId",
                table: "FlightBookTable",
                column: "TicketReserve_tblsResId",
                principalTable: "TicketReserve_tbl",
                principalColumn: "ResId");
        }
    }
}
