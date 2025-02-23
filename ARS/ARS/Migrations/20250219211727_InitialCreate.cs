using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLoginTable",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLoginTable", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "AeroPlaneInfo",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APlaneName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AeroPlaneInfo", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginTable",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CNo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginTable", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "FlightBookTable",
                columns: table => new
                {
                    bid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DTime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Planeid = table.Column<int>(type: "int", nullable: false),
                    PlaneInfoPlaneId = table.Column<int>(type: "int", nullable: false),
                    SeatType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookTable", x => x.bid);
                    table.ForeignKey(
                        name: "FK_FlightBookTable_AeroPlaneInfo_PlaneInfoPlaneId",
                        column: x => x.PlaneInfoPlaneId,
                        principalTable: "AeroPlaneInfo",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookTable_PlaneInfoPlaneId",
                table: "FlightBookTable",
                column: "PlaneInfoPlaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLoginTable");

            migrationBuilder.DropTable(
                name: "FlightBookTable");

            migrationBuilder.DropTable(
                name: "UserLoginTable");

            migrationBuilder.DropTable(
                name: "AeroPlaneInfo");
        }
    }
}
