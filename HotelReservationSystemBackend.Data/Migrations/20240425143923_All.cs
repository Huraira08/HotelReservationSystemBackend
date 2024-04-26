using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class All : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomNo = table.Column<int>(type: "int", nullable: false),
                    BookingRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoOfRooms = table.Column<int>(type: "int", nullable: false),
                    RentPerDay = table.Column<int>(type: "int", nullable: false),
                    ImagePaths = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Cnic = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRent = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRequest_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRequest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "ImagePaths", "Name", "NoOfRooms", "RentPerDay" },
                values: new object[,]
                {
                    { new Guid("36d578ed-d5e4-4d4f-b30f-3adf2005bcde"), "[]", "Five star hotel", 70, 4000 },
                    { new Guid("b3b61a54-162c-4e76-b229-ae6931dc500d"), "[]", "Royal hotel", 50, 5000 },
                    { new Guid("ef7f6a24-ce30-458c-9294-fe3056a6ab05"), "[]", "Luxury Hotel", 40, 7000 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Cnic", "Email", "Gender", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("3adc6ffb-7ca3-41bf-9954-9ce0b2f24bf3"), 26, "33293-5749302-1", "aslamazhar@gmail.com", 0, "Aslam Azhar", "aslam1234", 0 },
                    { new Guid("ee52e3a3-f664-41cd-979a-9cdf8beeb03c"), 30, "33889-170293-3", "admin@gmail.com", 0, "Admin", "Admin123", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_HotelId",
                table: "BookingRequest",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_UserId",
                table: "BookingRequest",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allocation");

            migrationBuilder.DropTable(
                name: "BookingRequest");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
