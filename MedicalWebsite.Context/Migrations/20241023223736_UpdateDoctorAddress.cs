using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWebsite.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDoctorAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor_Adress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "894adc0f-dde5-4f59-af8d-33b267831b15", new DateTime(2024, 10, 24, 1, 37, 33, 433, DateTimeKind.Local).AddTicks(7009), "AQAAAAIAAYagAAAAEGYOiMKnPiYkt2wSa7MsWC/GrZTGj4St1KaDd3Z+HcA4y0WCmD+U47KXssQ0kq29lg==", "853a5d77-bf02-4f71-8346-6f52f99423d2", new DateTime(2024, 10, 24, 1, 37, 33, 433, DateTimeKind.Local).AddTicks(7133) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "0fe7b9b9-1106-47d6-8b42-b0b6064a8416", new DateTime(2024, 10, 24, 1, 37, 33, 554, DateTimeKind.Local).AddTicks(4472), "AQAAAAIAAYagAAAAEJF/46mSsYUAEFXrcL2z2ICPGgX3ghAwCbmuFxcxCaKHdPdEAFzukilkSZB4E1aRZQ==", "d79c49b2-bd8d-4620-969b-e509edda7deb", new DateTime(2024, 10, 24, 1, 37, 33, 554, DateTimeKind.Local).AddTicks(4612) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "ee0d6288-8f99-4427-8f27-599fe37ea7fe", new DateTime(2024, 10, 24, 1, 37, 33, 658, DateTimeKind.Local).AddTicks(7067), "AQAAAAIAAYagAAAAED2SI60xicdBLSAmjVfF1WkZMabs0GZJGi1BPLDK2U8tQFd1yOChtE5zh1zrWYwbwg==", "0779ffcf-28b6-4ac6-a425-2aa2ae095e7c", new DateTime(2024, 10, 24, 1, 37, 33, 658, DateTimeKind.Local).AddTicks(7239) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor_Adress",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "3c119bb2-09ef-4900-8d80-bf0d7cab1c87", new DateTime(2024, 10, 19, 19, 6, 47, 336, DateTimeKind.Local).AddTicks(3303), "AQAAAAIAAYagAAAAECIFd3ksfjAk+yMQX9PIDPdvSKI+cOj18bDH9JoKNEwH9dTalL37MDBwVYVq4JUxnQ==", "ef8de460-95a6-4e17-9e71-69ef662125a4", new DateTime(2024, 10, 19, 19, 6, 47, 336, DateTimeKind.Local).AddTicks(3428) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "5720cfc0-5438-4623-a008-0e6226773785", new DateTime(2024, 10, 19, 19, 6, 47, 477, DateTimeKind.Local).AddTicks(9603), "AQAAAAIAAYagAAAAEBjSceil+f0NQTqk7l+l7Lmq60pFD/xakIIkOhpDQdtwJJ4fs8HLnjh0V+XL/l1FAQ==", "6e635cce-be24-4bc2-858c-62544e01dfe8", new DateTime(2024, 10, 19, 19, 6, 47, 477, DateTimeKind.Local).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "08d52bb8-3d53-445b-b64f-8afcb46ecfbb", new DateTime(2024, 10, 19, 19, 6, 47, 633, DateTimeKind.Local).AddTicks(2489), "AQAAAAIAAYagAAAAEDPx5qfS66n7AxIkj7qbcNx0jzNqxMDH4xscvfzifYEStjNU6uihHEsz8lkUUWEhcw==", "072fa13c-3f55-4594-a045-0ed8281128f2", new DateTime(2024, 10, 19, 19, 6, 47, 633, DateTimeKind.Local).AddTicks(2621) });
        }
    }
}
