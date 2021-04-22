using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRentalShop.Persistance.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Name", "StatusId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Firma", 0 });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Name", "StatusId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Firma", 0 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AgeCustomer", "Created", "CreatedBy", "CustomerStatusId", "CustomerTypeId", "Inactivated", "InactivatedBy", "IsActiv", "Modified", "ModifiedBy", "NIP", "Name", "REGON", "RegistrationDate", "StatusId" },
                values: new object[] { 1, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, null, null, true, null, null, "6591786532", "Comarch", "", new DateTime(2021, 4, 22, 12, 42, 23, 964, DateTimeKind.Local).AddTicks(9150), 0 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AgeCustomer", "Created", "CreatedBy", "CustomerStatusId", "CustomerTypeId", "Inactivated", "InactivatedBy", "IsActiv", "Modified", "ModifiedBy", "NIP", "Name", "REGON", "RegistrationDate", "StatusId" },
                values: new object[] { 2, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, null, null, true, null, null, "6591786534", "Jantar", "", new DateTime(2021, 4, 22, 12, 42, 23, 966, DateTimeKind.Local).AddTicks(6864), 0 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressType", "BuildingNumber", "City", "Country", "Created", "CreatedBy", "CustomerId", "FlatNumber", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Firmowy", "179", "Kraków", "Poland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "2B", null, null, null, null, 0, "Jana Pawła II", "43-300" },
                    { 2, "Firmowy", "179", "Bielsko-Biała", "Poland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "6B", null, null, null, null, 0, "Piekarska II", "43-300" }
                });

            migrationBuilder.InsertData(
                table: "ContactPersons",
                columns: new[] { "Id", "Created", "CreatedBy", "CustomerId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Position", "StatusId", "PersonName_FirstName", "PersonName_LastName", "PersonName_SecondName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, null, null, null, "Sekretarka", 0, "Jaś", "Fasola", "" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, null, null, null, "Sekretarka", 0, "Kaczor", "Donald", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactPersons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactPersons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
