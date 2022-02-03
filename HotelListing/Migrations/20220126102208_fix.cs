using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "015ed8bf-dc8a-4018-a1e1-a923e6ca48b9", "b928ff1c-e63e-4256-b2b8-075b165be8ae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d6dda4f-6df0-417c-a41b-cdd041a2d187", "baf57bcf-36a2-405a-a8df-7c483e7ae4c6", "ADMINSTRATOR", "ADMINSTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "015ed8bf-dc8a-4018-a1e1-a923e6ca48b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d6dda4f-6df0-417c-a41b-cdd041a2d187");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4daa0a47-e15f-4588-ab2a-e9bc21c414d5", "a84bdf14-e2b4-4de8-abc8-d758524400b0", "ADMINSTRATOR", "ADMINSTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "818b019b-1513-4f22-b68d-2fff5e6a7b69", "c14eb1ca-e425-4cd7-b5cc-6abb9ba64244", "User", "USER" });
        }
    }
}
