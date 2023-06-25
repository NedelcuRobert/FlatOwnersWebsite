using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOA.BACKEND.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class removeApartmentAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Addresses_AddressId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_AddressId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "HothBathroom",
                table: "WaterConsumptions",
                newName: "HotBathroom");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8929acb-345a-49d5-a95c-98e284ed398b", "AQAAAAIAAYagAAAAEK7eFtEYNMgI7i3iynOi0zrn+P96mCdayezzWayjrEBEtMpRe2KSLZD6ksQqaTrI/w==", "5aee47dc-6325-4322-b6cf-587c7c8ffd9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a27620-a44f-4543-9dk6-0993d048sia7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d13bccf3-48ec-4dd7-adfc-95ba34237f49", "AQAAAAIAAYagAAAAENtYlGpzlw1EHi5+7BqJZ1lZJIFi0/x8/o79Il8Wlb6czbiLa/0s3DVha4y/qIc05Q==", "cb9590e7-599e-4bb0-816f-edadeaec29bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c44780-a24d-4543-9cc6-0993d048aacu7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "079d7f5f-c491-47f4-acad-076eafa50c1b", "AQAAAAIAAYagAAAAEBPdv+AW1pcAOwlDzgwLPC/guIu726MRyUAPXGU4PIrGGdU5EUNhjBk9akpgGL1pOg==", "a4a9e4fc-576b-4683-9801-93eced66a6d5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Building",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "HotBathroom",
                table: "WaterConsumptions",
                newName: "HothBathroom");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_AddressId",
                table: "Apartments",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Addresses_AddressId",
                table: "Apartments",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
