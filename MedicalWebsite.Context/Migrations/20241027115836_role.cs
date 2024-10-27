using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWebsite.Context.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "5f5efa84-87bd-43d0-89da-a751b8c5c5a5", new DateTime(2024, 10, 27, 14, 58, 32, 879, DateTimeKind.Local).AddTicks(8839), "AQAAAAIAAYagAAAAECBrvwoMrAjQ90yC+YOUC44TmvxCETPXWvqiXgYfVQ8VGOkXhYsD9mvUi7jg4FwFgA==", "3e35599a-b09e-4821-9d7a-2e3df78eeb5e", new DateTime(2024, 10, 27, 14, 58, 32, 879, DateTimeKind.Local).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "2b27ac72-65bb-45b9-8031-3fc4133353c1", new DateTime(2024, 10, 27, 14, 58, 32, 983, DateTimeKind.Local).AddTicks(8144), "AQAAAAIAAYagAAAAEPcG92FLWyTwqG4Q/i3nAy/Ba6/vMoNWshY/3EpFPm0oNLCWZC9niwQa8LikNBu/iw==", "0a130721-c295-4cb8-9182-44f9c46e3bb9", new DateTime(2024, 10, 27, 14, 58, 32, 983, DateTimeKind.Local).AddTicks(8276) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "d98f43ff-5513-4af3-8ddf-9010769c42eb", new DateTime(2024, 10, 27, 14, 58, 33, 88, DateTimeKind.Local).AddTicks(5820), "AQAAAAIAAYagAAAAEEbhzOFhKV8TQjZaoNKK7BzlHLG/2tt48IAil8UQoyV8cKQ64IXQ+ctjY+OlpdLPHg==", "dc0b359f-2a76-4664-ac7e-25e61c12be32", new DateTime(2024, 10, 27, 14, 58, 33, 88, DateTimeKind.Local).AddTicks(5971) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
