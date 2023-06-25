using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOA.BACKEND.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "c3ab8d96-0d7b-43f1-a211-0ccc501af37a", "AQAAAAIAAYagAAAAEObLGnBqq2g9xloSQ+rV7045WKI9lA43NWxlUngJJC1DUg+7QpTmiEwfzO0mZ5Af8Q==", "1", "9e6e2d6e-9586-471e-806a-5e7243f50faf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a27620-a44f-4543-9dk6-0993d048sia7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "f6d5653d-738e-454d-b546-cce07bf6857c", "AQAAAAIAAYagAAAAEDmWZe6DiENB87y/pSMIl5rQwlEnwXKBk7YMXdDzh1uarLUHWSjIfP9KgZSbXKcOUw==", "1", "e125fa02-39a7-4eed-8247-be7f3a406ae7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c44780-a24d-4543-9cc6-0993d048aacu7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "b33f5d9f-da80-408b-8b29-b588548d4f37", "AQAAAAIAAYagAAAAEPPMou8yTaMFQSFlqm8lqwS2a+wTuvQtmwX6N9jCX8+dMqSSZpy3nMZkP4NHjF4OAA==", "1", "ce555a06-0b5d-4683-9ce9-4b1c251a221f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

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
    }
}
