using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWebsite.Context.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpfulVotes",
                table: "Reviews");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HelpfulVotes",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "57e12d79-1525-483b-b409-8a97fb40d53d", new DateTime(2024, 10, 2, 22, 33, 12, 253, DateTimeKind.Local).AddTicks(7301), "AQAAAAIAAYagAAAAEC0mfrKc7O+Ts7K1jNeMd3RueplasOak/bANJXJOY43U4JxyUWCydZQ5rcwaOop5GQ==", "27a2af2b-3194-4b8c-acd0-8ebc20286e30", new DateTime(2024, 10, 2, 22, 33, 12, 253, DateTimeKind.Local).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "6bee19ed-ee64-4142-a3df-38230df53c68", new DateTime(2024, 10, 2, 22, 33, 12, 319, DateTimeKind.Local).AddTicks(4555), "AQAAAAIAAYagAAAAEIuydS3BQ+KePnKtLd9EB7AevOu6hAidPqFAsMFFtb9akzn9Nus+WUQ5im2qc+pYGw==", "be913667-a92a-41cb-ba7f-27c0a08113cd", new DateTime(2024, 10, 2, 22, 33, 12, 319, DateTimeKind.Local).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "88849c66-5c12-4ea5-9fe9-698b44e4d8b9", new DateTime(2024, 10, 2, 22, 33, 12, 393, DateTimeKind.Local).AddTicks(8287), "AQAAAAIAAYagAAAAEGNo4ZKfwDopM2jLN9+iqT9nHYMszLJz6AeZDsYrYeyeDpQ1b2/Nb68mP13kxgJXZg==", "05cd6219-2736-4524-a5cb-f48fdc93dfb0", new DateTime(2024, 10, 2, 22, 33, 12, 393, DateTimeKind.Local).AddTicks(8339) });
        }
    }
}
