
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncludeHotelInBookingRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_HotelId",
                table: "BookingRequest",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRequest_Hotel_HotelId",
                table: "BookingRequest",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRequest_Hotel_HotelId",
                table: "BookingRequest");

            migrationBuilder.DropIndex(
                name: "IX_BookingRequest_HotelId",
                table: "BookingRequest");

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
    }
}
