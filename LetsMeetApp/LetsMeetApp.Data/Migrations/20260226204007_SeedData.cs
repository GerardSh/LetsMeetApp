using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LetsMeetApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "Bio", "BirthDate", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), 0, null, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia", "10850671-ee81-40f1-837e-bf18bef9c0b5", "Bulgaria", "admin@letsmeet.com", true, "System", "Admin", false, null, "ADMIN@LETSMEET.COM", "ADMIN@LETSMEET.COM", "AQAAAAIAAYagAAAAEFSEH0Cf94mKE/j8ZHPDb7oaLF2tLT+53BFCrbqqNjzC2TlUeU7KKkLH5eFdWVbcEA==", null, false, "11111111-1111-1111-1111-111111111111", false, "admin@letsmeet.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "Sports" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "Music" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "Technology" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, "Travel" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, "Gaming" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, "Cinema" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "City", "Country", "CreatorId", "Date", "Description", "ImageUrl", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("22222222-2222-2222-2222-222222222222"), "Sofia", "Bulgaria", new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 1, 20, 30, 0, 0, DateTimeKind.Local), "Join us for a live music session!", "https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4", "Downtown Club", "Music Jam Session" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("11111111-1111-1111-1111-111111111111"), "Sofia", "Bulgaria", new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 3, 13, 0, 0, 0, DateTimeKind.Local), "Casual football match for all skill levels", "https://images.unsplash.com/photo-1486286701208-1d58e9338013", "City Park Stadium", "Weekend Soccer" }
                });

            migrationBuilder.InsertData(
                table: "EventParticipations",
                columns: new[] { "Id", "EventId", "JoinedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 2, 26, 20, 40, 6, 742, DateTimeKind.Utc).AddTicks(706), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 2, 26, 20, 40, 6, 742, DateTimeKind.Utc).AddTicks(711), new Guid("11111111-1111-1111-1111-111111111111") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "EventParticipations",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "EventParticipations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
