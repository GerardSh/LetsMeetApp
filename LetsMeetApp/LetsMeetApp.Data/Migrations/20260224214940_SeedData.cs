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
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), 0, null, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia", "d63ba79c-82d8-49da-bab4-033d07555bfb", "Bulgaria", "admin@letsmeet.com", true, "Admin", "Admin", false, null, "ADMIN@LETSMEET.COM", "ADMIN@LETSMEET.COM", "AQAAAAIAAYagAAAAENBtA0G3IhsUa0Hrs45YlHhZJ+GwaFeALw0kFKwKdC9tq8AR4ur2cRx7tkIkNBroqg==", null, false, "ecff9c4e-28b0-4c48-9b5d-eba7a8fae6ce", false, "admin@letsmeet.com" });

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
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "City", "Country", "CreatorId", "Date", "Description", "ImageUrl", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null, new Guid("22222222-2222-2222-2222-222222222222"), "Sofia", "Bulgaria", new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 27, 21, 49, 39, 437, DateTimeKind.Utc).AddTicks(8025), "Join us for a live music session!", "https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4?auto=format&fit=crop&w=800&q=80", "Downtown Club", "Music Jam Session" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null, new Guid("11111111-1111-1111-1111-111111111111"), "Sofia", "Bulgaria", new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 1, 21, 49, 39, 437, DateTimeKind.Utc).AddTicks(8040), "Casual football match for all skill levels", "https://unsplash.com/photos/white-and-blue-soccer-ball-on-green-grass-field-OgqWLzWRSaI", "City Park Stadium", "Weekend Soccer" }
                });

            migrationBuilder.InsertData(
                table: "EventParticipations",
                columns: new[] { "Id", "EventId", "JoinedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-1111-aaaa-1111-aaaaaaaaaaaa"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 2, 24, 21, 49, 39, 437, DateTimeKind.Utc).AddTicks(8072), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bbbbbbbb-2222-bbbb-2222-bbbbbbbbbbbb"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 2, 24, 21, 49, 39, 437, DateTimeKind.Utc).AddTicks(8083), new Guid("11111111-1111-1111-1111-111111111111") }
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
