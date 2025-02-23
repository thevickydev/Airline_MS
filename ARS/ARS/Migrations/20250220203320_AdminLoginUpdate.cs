using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARS.Migrations
{
    /// <inheritdoc />
    public partial class AdminLoginUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_AeroPlaneInfo_PlaneInfoPlaneId",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "To",
                table: "FlightBookTable");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserLoginTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CPassword",
                table: "UserLoginTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "SeatType",
                table: "FlightBookTable",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "PlaneInfoPlaneId",
                table: "FlightBookTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DTime",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "CusAddress",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CusCnic",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CusEmail",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CusName",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CusPhone",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CusSeat",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResId",
                table: "FlightBookTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketReserve_tblsResId",
                table: "FlightBookTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bCusName",
                table: "FlightBookTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketReserve_tbl",
                columns: table => new
                {
                    ResId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ResDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResFtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneId = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    plane_tblsPlaneId = table.Column<int>(type: "int", nullable: true),
                    PlaneSeat = table.Column<int>(type: "int", nullable: false),
                    ResTicketPrice = table.Column<float>(type: "real", nullable: false),
                    ResPlaneType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReserve_tbl", x => x.ResId);
                    table.ForeignKey(
                        name: "FK_TicketReserve_tbl_AeroPlaneInfo_plane_tblsPlaneId",
                        column: x => x.plane_tblsPlaneId,
                        principalTable: "AeroPlaneInfo",
                        principalColumn: "PlaneId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookTable_TicketReserve_tblsResId",
                table: "FlightBookTable",
                column: "TicketReserve_tblsResId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReserve_tbl_plane_tblsPlaneId",
                table: "TicketReserve_tbl",
                column: "plane_tblsPlaneId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_AeroPlaneInfo_PlaneInfoPlaneId",
                table: "FlightBookTable");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookTable_TicketReserve_tbl_TicketReserve_tblsResId",
                table: "FlightBookTable");

            migrationBuilder.DropTable(
                name: "TicketReserve_tbl");

            migrationBuilder.DropIndex(
                name: "IX_FlightBookTable_TicketReserve_tblsResId",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "CusAddress",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "CusCnic",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "CusEmail",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "CusName",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "CusPhone",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "CusSeat",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "ResId",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "TicketReserve_tblsResId",
                table: "FlightBookTable");

            migrationBuilder.DropColumn(
                name: "bCusName",
                table: "FlightBookTable");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserLoginTable",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CPassword",
                table: "UserLoginTable",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SeatType",
                table: "FlightBookTable",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaneInfoPlaneId",
                table: "FlightBookTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DTime",
                table: "FlightBookTable",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FlightBookTable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "FlightBookTable",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookTable_AeroPlaneInfo_PlaneInfoPlaneId",
                table: "FlightBookTable",
                column: "PlaneInfoPlaneId",
                principalTable: "AeroPlaneInfo",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
