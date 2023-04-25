using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBlog.Migrations
{
    /// <inheritdoc />
    public partial class Addingnormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "400ffb69-42f7-46ee-8f96-c86110589499",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1683714-e627-425e-9197-fdfc375980f2", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAEAACcQAAAAEMtsYQcId/o7hC/ZANVInKmIkWBvPV2CrondDD8LOrQVt8YDO7u33ce79bpAuhInUA==", "e492db2f-9fa7-4e11-a3ba-03697d8b24e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "400ffb69-42f7-46ee-8f96-c86110589499",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a24a849-c886-422d-910a-6c838d5e4278", null, null, "AQAAAAEAACcQAAAAEEIDjbSy783RCjorguNa5QlvLcKb+40SdUEmmBoFrvHRIbu0G2EoTC9y4CNdfwHM6g==", "4a455c9c-8c47-4818-b207-9d16d0c04d04" });
        }
    }
}
