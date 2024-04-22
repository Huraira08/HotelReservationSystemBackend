using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("10af5a4e-bbcf-4cbc-9c43-4af3a6ab0643"));

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("18fd99db-15fd-45f4-8b38-73cff59d745f"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("10af5a4e-bbcf-4cbc-9c43-4af3a6ab0643"), "[]", "Royal hotel", 50, 5000 },
                    { new Guid("18fd99db-15fd-45f4-8b38-73cff59d745f"), "[]", "Five star hotel", 70, 4000 }
                });
        }
    }
}
