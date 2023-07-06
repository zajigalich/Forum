using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.API.Migrations
{
    /// <inheritdoc />
    public partial class InsertiongDataForUsersAndIgnoringUnnecessaryfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "483b5d6e-6098-4392-ac76-37a9c76d4561",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bc44184-59c0-44ce-81fd-989f874fd0e1", "ADMIN@FORUM.COM", "AQAAAAEAACcQAAAAEMRNXif1y4xLa1OBP+XtiJ9kH+oktDl1JzNRwNc/hisS6JXXhPyoVfyzJ9yyjGhKoQ==", "53e8ff99-5d89-4788-93b6-960269de9cc0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bd0b433-3eb3-4c51-9ef6-23323e0ec16c",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1f7596e-5c44-4fbc-8e6c-c66ac879e755", "POSTER@FORUM.COM", "AQAAAAEAACcQAAAAEA5zn1w9OXJhnb0dH/O4ahJbad/JD+up3+q02VKCSKHC/q0tZaVfQfujuOqlgTUFIQ==", "d47e4b02-d7df-428d-b4b9-c26f8a5c5098" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "483b5d6e-6098-4392-ac76-37a9c76d4561",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "920373a7-714f-48a0-bf54-6ecc7efbb26b", true, false, null, null, "AQAAAAEAACcQAAAAELZOrjmSAXgHd4AaOfo2I+bKiovSLK81JGEQ3qCjf+aHusQHfs7Koc2/UsbTL9sX3A==", null, false, "48d90102-3de2-43b6-a69a-237d1ae9ed9c", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bd0b433-3eb3-4c51-9ef6-23323e0ec16c",
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled" },
                values: new object[] { 0, "fb2973ab-8b62-4dbe-bb7f-4bc2c3011dd7", true, false, null, null, "AQAAAAEAACcQAAAAEIeMueRHgnW7SfiOyExE3EAVkbg6k89u+w2yrHANQeEKM98DEqzw/UND6Cf+gYD64Q==", null, false, "e8474279-d352-4fdd-b75c-c267c5bfffa0", false });
        }
    }
}
