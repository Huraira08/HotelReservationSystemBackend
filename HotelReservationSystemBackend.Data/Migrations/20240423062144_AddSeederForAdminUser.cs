using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeederForAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("b50410bc-b5a7-4cf4-a8ea-0e94d96edad4"));

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("f5a7f82d-c755-4106-94f8-9cbb0befe123"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e2067bca-292c-4eab-a9de-a4fdeb1f9bc0"));

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "ImagePaths", "Name", "NoOfRooms", "RentPerDay" },
                values: new object[,]
                {
                    { new Guid("4f29f30d-79da-4058-aa33-84bb1d9de6a4"), "[]", "Royal hotel", 50, 5000 },
                    { new Guid("f07a50ba-f3f0-41e1-92cd-748174d33f76"), "[]", "Five star hotel", 70, 4000 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Cnic", "Email", "Gender", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("4660b767-a47a-49e3-8952-365275188cd9"), 30, "33889-170293-3", "admin@gmail.com", 0, "Admin", "Admin123", 1 },
                    { new Guid("beba5d2b-ae7e-403d-8c00-f918489c2bcc"), 26, "33293-5749302-1", "aslamazhar@gmail.com", 0, "Aslam Azhar", "aslam1234", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("4f29f30d-79da-4058-aa33-84bb1d9de6a4"));

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("f07a50ba-f3f0-41e1-92cd-748174d33f76"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4660b767-a47a-49e3-8952-365275188cd9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("beba5d2b-ae7e-403d-8c00-f918489c2bcc"));

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "ImagePaths", "Name", "NoOfRooms", "RentPerDay" },
                values: new object[,]
                {
                    { new Guid("b50410bc-b5a7-4cf4-a8ea-0e94d96edad4"), "[]", "Five star hotel", 70, 4000 },
                    { new Guid("f5a7f82d-c755-4106-94f8-9cbb0befe123"), "[]", "Royal hotel", 50, 5000 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Cnic", "Email", "Gender", "Name", "Password", "Role" },
                values: new object[] { new Guid("e2067bca-292c-4eab-a9de-a4fdeb1f9bc0"), 26, "33293-5749302-1", "aslamazhar@gmail.com", 0, "Aslam Azhar", "aslam1234", 0 });
        }
    }
}
