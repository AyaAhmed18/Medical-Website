using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalWebsite.Context.Migrations
{
    /// <inheritdoc />
    public partial class spelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "watingTime",
                table: "Bookings",
                newName: "waitngTime");

            migrationBuilder.RenameColumn(
                name: "Doctor_Phone",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "eb82052d-0b7b-417a-b6a3-05cbf1eef195", new DateTime(2024, 10, 25, 15, 41, 14, 229, DateTimeKind.Local).AddTicks(6315), "AQAAAAIAAYagAAAAEC0MmhiO+qR9hN0LpaYFmY+2yFa4maXWSTUTeByQZDxSRi1siyF2TqKIkHKlsOS6YQ==", "aca25d78-af94-48f8-970f-d1074df03e6c", new DateTime(2024, 10, 25, 15, 41, 14, 229, DateTimeKind.Local).AddTicks(6328) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "a2708b25-19d1-454f-b2e5-0091644b4cfe", new DateTime(2024, 10, 25, 15, 41, 14, 296, DateTimeKind.Local).AddTicks(9395), "AQAAAAIAAYagAAAAEGgQTgrViAWEH7sG9u1bcE9uVsipQzCSsHAy6iaTTcgunmQLJBzg2xbIKUBMNPv6Iw==", "f499e709-8f50-4246-8078-5b7e56f8efe9", new DateTime(2024, 10, 25, 15, 41, 14, 296, DateTimeKind.Local).AddTicks(9409) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "e2a5b48a-9643-4098-902c-e8ea921e4eeb", new DateTime(2024, 10, 25, 15, 41, 14, 361, DateTimeKind.Local).AddTicks(9725), "AQAAAAIAAYagAAAAEDH9TZ3DnApDN7LPhcmipKQXNM40zcFWbFhHgwGeqb8wkHSCS8GhspY9XXQ2ByaJvg==", "70a30459-6074-4406-981f-43c1d89bdcba", new DateTime(2024, 10, 25, 15, 41, 14, 361, DateTimeKind.Local).AddTicks(9739) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "waitngTime",
                table: "Bookings",
                newName: "watingTime");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "Doctor_Phone");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
