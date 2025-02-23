using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARS.Migrations
{
    /// <inheritdoc />
    public partial class Flights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CusEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CusPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CusCnic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false),
                    PlaneSeat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<double>(type: "float", nullable: false),
                    SeatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Flights_UserLoginTable_UserID",
                        column: x => x.UserID,
                        principalTable: "UserLoginTable",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_UserID",
                table: "Flights",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
