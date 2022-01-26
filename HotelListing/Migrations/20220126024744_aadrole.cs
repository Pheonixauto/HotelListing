using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class aadrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae26ece-1a76-4da3-9c50-f3b3717c1f6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c30d40b-bebd-4208-a6f1-4d264bb08242");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d6048ee-f43d-4dcb-aa41-98b7d531a42f", "7cca739f-d4de-461f-b53e-966d1824e514", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a63dd6c6-da38-4cfa-aef8-a6d4e186223c", "5b9d43a8-2e45-45fb-9a88-aff9e5ea07ab", "Aministrator", "ADMINSTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d6048ee-f43d-4dcb-aa41-98b7d531a42f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a63dd6c6-da38-4cfa-aef8-a6d4e186223c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ae26ece-1a76-4da3-9c50-f3b3717c1f6f", "c8f6c9d5-bde9-45cd-9859-f00b3bbd618f", "Aministrator", "ADMINSTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c30d40b-bebd-4208-a6f1-4d264bb08242", "782be37a-fb3f-4453-acae-2c5fd058a976", "User", "USER" });
        }
    }
}
