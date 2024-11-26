using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWebsite.Context.Migrations
{
    /// <inheritdoc />
    public partial class image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Treatment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "40dfd5b6-0bb9-4f23-8cce-896ff58303e1", new DateTime(2024, 11, 26, 19, 13, 51, 510, DateTimeKind.Local).AddTicks(45), "AQAAAAIAAYagAAAAEO1b0oHwlKnD3OcUKQR3x9WoerNhKYwx17AU2MqBTwC9HeheVG463Pv+aODsrw6fJA==", "69efafa5-348c-4a71-964f-f25b5388f51d", new DateTime(2024, 11, 26, 19, 13, 51, 510, DateTimeKind.Local).AddTicks(186) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "d22501ff-0560-4ecf-877f-7c32535f0916", new DateTime(2024, 11, 26, 19, 13, 51, 618, DateTimeKind.Local).AddTicks(4365), "AQAAAAIAAYagAAAAEOBjR1aKiRI+F/9kzN4H7acxOBaHi22cLpe/xsyaDeklcYOg+23lzhbX+Nmn1CwW1g==", "5e3f171e-5c0b-47cc-bd0b-7caf4be43140", new DateTime(2024, 11, 26, 19, 13, 51, 618, DateTimeKind.Local).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "f114fd72-ec1f-4f20-a8e5-52d88b04bf69", new DateTime(2024, 11, 26, 19, 13, 51, 723, DateTimeKind.Local).AddTicks(2881), "AQAAAAIAAYagAAAAEIWWWh9CmNrf7K5ijLGsq5C59CVWLyYBR1odQx9hOR50Z8Q7k2RIuoS4biE0noVARQ==", "55da0f4d-fa4b-41f6-8328-ddfe4fb3d295", new DateTime(2024, 11, 26, 19, 13, 51, 723, DateTimeKind.Local).AddTicks(3010) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Treatment");

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
    }
}
