using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOA.BACKEND.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedAccountsAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartmentNumber", "Building", "City", "Street" },
                values: new object[,]
                {
                    { 1, 1, "6 Scara 2", "Craiova", "Florilor" },
                    { 2, 1, "6 Scara 2", "Craiova", "Florilor" },
                    { 3, 1, "6 Scara 2", "Craiova", "Florilor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Token", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb7", 0, 1, "9cf08dc7-d69a-4063-8cf5-ce8621469bdc", "norole@gmail.com", true, "Andrei", "Popescu", true, null, "NOROLE@GMAIL.COM", "NOROLE", "AQAAAAIAAYagAAAAEJHAeUMNpPFVN1HlDegUu6o4qCw//0JDUpVzc7vmgrIrcxfaU2WaEyPYcHvaW7Q7Mg==", null, false, "10aa5039-1606-4c45-a83b-7a90621a27a9", "12121212", false, "NoRole" },
                    { "9a27620-a44f-4543-9dk6-0993d048sia7", 0, 3, "72bd8e32-b208-471c-807c-a5b04ae9386c", "bto@gmail.com", true, "Andrei", "Popescu", true, null, "BTO@GMAIL.COM", "BTO", "AQAAAAIAAYagAAAAENa1cqm3MDH1v9zahls6psQ1XRpCVJYbxQeHlPT3lN3bDACO8lFOthIaCLkyEszgRw==", null, false, "2fcef03a-79f5-4b9d-88b2-8cfa546db731", "12121212", false, "BTO" },
                    { "9c44780-a24d-4543-9cc6-0993d048aacu7", 0, 2, "6a701b50-4bb6-445e-a973-1baaa40e5781", "atmin@gmail.com", true, "Andrei", "Popescu", true, null, "ATMIN@GMAIL.COM", "ATMIN", "AQAAAAIAAYagAAAAEI3UbJDnCamk4sPsA7h5y4AKOFtw/m4az0miq70ZFc8wIK44Gt6t/Rs3bDkZdV6KoQ==", null, false, "57d5683f-243d-4b91-a5fc-8799a0c2191c", "12121212", false, "Atmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a27620-a44f-4543-9dk6-0993d048sia7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c44780-a24d-4543-9cc6-0993d048aacu7");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");
        }
    }
}
