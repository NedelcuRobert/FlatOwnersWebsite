using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOA.BACKEND.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class update_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdded",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdded",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAdded",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10898a8a-4d7c-4b41-9d08-72c0f6485295", "AQAAAAIAAYagAAAAENt96VPpP+yTR21OfBSt/W2rNOSQ+w/zew/qRK6JMKcoNf9OfQWTf5NcfCWj0jd+ww==", "6abbbe6f-0049-4006-b0bc-ea1efc3d8d3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a27620-a44f-4543-9dk6-0993d048sia7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa4f91fb-968f-4e5a-8181-c4de9d2f7587", "AQAAAAIAAYagAAAAEEMFPADR50Di78YtvPt5t6YnLTbjxmuxPo4hazALUI2hBut2ZyW3b/4cK/3NIGUlBA==", "1a46af9f-790d-451f-a7b0-a49f41fb0e97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c44780-a24d-4543-9cc6-0993d048aacu7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed64dc37-f5bb-484a-b5fc-18bdfbde1b92", "AQAAAAIAAYagAAAAECqUAZ/C12V1c7/UMMzAuvNZGX59tsnmyb/iCxPjQ1fmX0HnnoAgDzCDUghKP2Vdbw==", "8ba1b3e4-622a-4cee-9a07-db0f5b902305" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAdded",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DataAdded",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DataAdded",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Apartments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cf08dc7-d69a-4063-8cf5-ce8621469bdc", "AQAAAAIAAYagAAAAEJHAeUMNpPFVN1HlDegUu6o4qCw//0JDUpVzc7vmgrIrcxfaU2WaEyPYcHvaW7Q7Mg==", "10aa5039-1606-4c45-a83b-7a90621a27a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a27620-a44f-4543-9dk6-0993d048sia7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72bd8e32-b208-471c-807c-a5b04ae9386c", "AQAAAAIAAYagAAAAENa1cqm3MDH1v9zahls6psQ1XRpCVJYbxQeHlPT3lN3bDACO8lFOthIaCLkyEszgRw==", "2fcef03a-79f5-4b9d-88b2-8cfa546db731" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c44780-a24d-4543-9cc6-0993d048aacu7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a701b50-4bb6-445e-a973-1baaa40e5781", "AQAAAAIAAYagAAAAEI3UbJDnCamk4sPsA7h5y4AKOFtw/m4az0miq70ZFc8wIK44Gt6t/Rs3bDkZdV6KoQ==", "57d5683f-243d-4b91-a5fc-8799a0c2191c" });
        }
    }
}
