using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class changenameroleAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4daa0a47-e15f-4588-ab2a-e9bc21c414d5", "a84bdf14-e2b4-4de8-abc8-d758524400b0", "ADMINSTRATOR", "ADMINSTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "818b019b-1513-4f22-b68d-2fff5e6a7b69", "c14eb1ca-e425-4cd7-b5cc-6abb9ba64244", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4daa0a47-e15f-4588-ab2a-e9bc21c414d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818b019b-1513-4f22-b68d-2fff5e6a7b69");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d6048ee-f43d-4dcb-aa41-98b7d531a42f", "7cca739f-d4de-461f-b53e-966d1824e514", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a63dd6c6-da38-4cfa-aef8-a6d4e186223c", "5b9d43a8-2e45-45fb-9a88-aff9e5ea07ab", "Aministrator", "ADMINSTRATOR" });
        }
    }
}
