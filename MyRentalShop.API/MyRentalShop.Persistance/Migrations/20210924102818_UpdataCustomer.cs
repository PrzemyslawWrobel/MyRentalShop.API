using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRentalShop.Persistance.Migrations
{
    public partial class UpdataCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 9, 24, 12, 28, 17, 706, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2021, 9, 24, 12, 28, 17, 711, DateTimeKind.Local).AddTicks(2963));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 9, 9, 16, 6, 10, 163, DateTimeKind.Local).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2021, 9, 9, 16, 6, 10, 170, DateTimeKind.Local).AddTicks(8403));
        }
    }
}
