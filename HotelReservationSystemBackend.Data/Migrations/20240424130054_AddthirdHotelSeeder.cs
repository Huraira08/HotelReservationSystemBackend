using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddthirdHotelSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("48067300-d8d9-4dac-b33f-46f881b9a8e7"));

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("ba546675-9868-4458-b449-665b5135212f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d0cef272-5293-4b61-a780-6ae932cc29eb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ec6ccbdd-cedc-4bfb-956e-2fb7a232cd49"));

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "ImagePaths", "Name", "NoOfRooms", "RentPerDay" },
                values: new object[,]
                {
                    { new Guid("1b8792a1-6422-4219-8764-11ecd9c2bcce"), "[]", "Five star hotel", 70, 4000 },
                    { new Guid("37bd6bbb-0c61-4df6-af41-edf680d97c33"), "[]", "Luxury Hotel", 40, 7000 },
                    { new Guid("9ace5662-77f8-46b1-926e-620f27e50e18"), "[]", "Royal hotel", 50, 5000 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Cnic", "Email", "Gender", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("9c762653-f6c5-406b-a722-0efd6f47baba"), 26, "33293-5749302-1", "aslamazhar@gmail.com", 0, "Aslam Azhar", "aslam1234", 0 },
                    { new Guid("e13fd475-8d10-4168-b4fd-5f82acafccf3"), 30, "33889-170293-3", "admin@gmail.com", 0, "Admin", "Admin123", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("1b8792a1-6422-4219-8764-11ecd9c2bcce"));

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("37bd6bbb-0c61-4df6-af41-edf680d97c33"));

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "Id",
                keyValue: new Guid("9ace5662-77f8-46b1-926e-620f27e50e18"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9c762653-f6c5-406b-a722-0efd6f47baba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e13fd475-8d10-4168-b4fd-5f82acafccf3"));

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "ImagePaths", "Name", "NoOfRooms", "RentPerDay" },
                values: new object[,]
                {
                    { new Guid("48067300-d8d9-4dac-b33f-46f881b9a8e7"), "[]", "Five star hotel", 70, 4000 },
                    { new Guid("ba546675-9868-4458-b449-665b5135212f"), "[]", "Royal hotel", 50, 5000 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Cnic", "Email", "Gender", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("d0cef272-5293-4b61-a780-6ae932cc29eb"), 30, "33889-170293-3", "admin@gmail.com", 0, "Admin", "Admin123", 1 },
                    { new Guid("ec6ccbdd-cedc-4bfb-956e-2fb7a232cd49"), 26, "33293-5749302-1", "aslamazhar@gmail.com", 0, "Aslam Azhar", "aslam1234", 0 }
                });
        }
    }
}
