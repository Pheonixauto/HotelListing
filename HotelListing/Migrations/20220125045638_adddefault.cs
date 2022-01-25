using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class adddefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ae26ece-1a76-4da3-9c50-f3b3717c1f6f", "c8f6c9d5-bde9-45cd-9859-f00b3bbd618f", "Aministrator", "ADMINSTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c30d40b-bebd-4208-a6f1-4d264bb08242", "782be37a-fb3f-4453-acae-2c5fd058a976", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae26ece-1a76-4da3-9c50-f3b3717c1f6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c30d40b-bebd-4208-a6f1-4d264bb08242");
        }
    }
}
