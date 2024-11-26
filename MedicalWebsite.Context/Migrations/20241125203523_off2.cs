using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWebsite.Context.Migrations
{
    /// <inheritdoc />
    public partial class off2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "2fca1dd6-01b4-4e26-9546-f2b3233ba4f9", new DateTime(2024, 11, 25, 22, 35, 20, 535, DateTimeKind.Local).AddTicks(8297), "AQAAAAIAAYagAAAAEBZoW3GSnt2JIfQqZqJGxSrljRTc7dd1vDm0a52v3ubXBf3JzhyEocxV32uSZqBJZg==", "baf5a6ff-ebc5-40f0-9d3f-20cc1403f4d5", new DateTime(2024, 11, 25, 22, 35, 20, 535, DateTimeKind.Local).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "16e7494e-36c4-45ce-9ba6-2b7c555ef387", new DateTime(2024, 11, 25, 22, 35, 20, 606, DateTimeKind.Local).AddTicks(1361), "AQAAAAIAAYagAAAAEFV0McDJkVRujuUwhC3r9czbXADsAlXO+FHoiogoszkCNju2F6VcvZDAfkA3jiRLyQ==", "b64e57de-04ce-4d4e-9028-22b49957264c", new DateTime(2024, 11, 25, 22, 35, 20, 606, DateTimeKind.Local).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "dc57b169-c191-400d-9d4b-0a011c270a88", new DateTime(2024, 11, 25, 22, 35, 20, 675, DateTimeKind.Local).AddTicks(7457), "AQAAAAIAAYagAAAAECdv5PxKqKDa+dYVbQA+xQhcBHT4169cxFf/NHpSJHt7oWNIn5dS8w4atbEXqmOeuQ==", "ae857664-b114-48ff-a66d-a7f53be94bd0", new DateTime(2024, 11, 25, 22, 35, 20, 675, DateTimeKind.Local).AddTicks(7531) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "253ccb3f-9192-4874-802e-1e6514a21e65", new DateTime(2024, 11, 25, 3, 57, 0, 593, DateTimeKind.Local).AddTicks(5074), "AQAAAAIAAYagAAAAEES10g8iE3V/yivMZ0Ma+Nh8Fi3zuNjq+1oGXCB/NCAw43Mbx5j/kssUDI/rax6tzQ==", "5397a1aa-15e9-4a05-ac73-20347a2f8f11", new DateTime(2024, 11, 25, 3, 57, 0, 593, DateTimeKind.Local).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "331f97a0-e945-43e6-b3a7-f9851a28cce2", new DateTime(2024, 11, 25, 3, 57, 0, 664, DateTimeKind.Local).AddTicks(7833), "AQAAAAIAAYagAAAAELJTwVpF8Zab91QE7I46W9WnbHMj4KSRtpMaHzyY45M0CA2si3/znFegbAiz37Fhdg==", "ee32a138-e4a8-4ab3-b230-88311aa2d6fb", new DateTime(2024, 11, 25, 3, 57, 0, 664, DateTimeKind.Local).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "63b94754-b024-493a-bf30-4db48d2af9dd", new DateTime(2024, 11, 25, 3, 57, 0, 742, DateTimeKind.Local).AddTicks(2023), "AQAAAAIAAYagAAAAEKUX8Q2I7TsjMz7/WCYwdz9Dz+URCrGtc5b5Z4wGqxoukHtbpuCX3Jf6LMkvnxGMaA==", "5d652c3c-30dd-4e0d-8cc9-98f7157bf6c9", new DateTime(2024, 11, 25, 3, 57, 0, 742, DateTimeKind.Local).AddTicks(2103) });
        }
    }
}
