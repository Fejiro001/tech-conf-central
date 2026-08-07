using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechConfCentral.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Conference",
                columns: new[] { "Id", "City", "Country", "Description", "EndDate", "Name", "StartDate", "StateOrProvince", "Tagline", "Venue" },
                values: new object[] { 1, "San Francisco", "USA", "The premier developer conference.", new DateOnly(2026, 11, 15), "DevHorizon 2026", new DateOnly(2026, 11, 15), "CA", "where code meets the machine_", "Pier 70" });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, 300, "Room A" },
                    { 2, 250, "Room B" },
                    { 3, 150, "Room C" },
                    { 4, 150, "Room D" }
                });

            migrationBuilder.InsertData(
                table: "Speaker",
                columns: new[] { "Id", "Biography", "Company", "FirstName", "IsFeatured", "JobTitle", "LastName", "ProfileImage" },
                values: new object[] { 1, "Elena has spent the last decade pushing the boundaries of in-browser development environments. She led the browser-native IDE initiative at Bytecraft and is a frequent contributor to the TC39 process. Her work focuses on making the web platform a first-class development target.", "Bytecraft", "Elena", true, "Principal Frontend Engineer", "Vasquez", "" });

            migrationBuilder.InsertData(
                table: "Speaker",
                columns: new[] { "Id", "Biography", "Company", "FirstName", "JobTitle", "LastName", "ProfileImage" },
                values: new object[] { 2, "Dinesh is a senior frontend engineer at Pied Piper, where he led the development of the Pied Piper video chat platform and the consumer-facing web interface. He specializes in real-time video compression on the client side and has deep experience with WebRTC, codec optimization, and building performant media experiences in the browser.", "Pied Piper", "Dinesh", "Senior Frontend Engineer", "Chugtai", "" });

            migrationBuilder.InsertData(
                table: "Speaker",
                columns: new[] { "Id", "Biography", "Company", "FirstName", "IsFeatured", "JobTitle", "LastName", "ProfileImage" },
                values: new object[] { 3, "James oversees Cartwell's frontend platform team, managing the monorepo that powers thousands of internal and merchant-facing applications. He's a vocal advocate for developer experience as a product concern and has led the company's migration to a unified build system serving over 300 engineers.", "Cartwell", "James", true, "Engineering Director", "Okonkwo", "" });

            migrationBuilder.InsertData(
                table: "Speaker",
                columns: new[] { "Id", "Biography", "Company", "FirstName", "JobTitle", "LastName", "ProfileImage" },
                values: new object[] { 4, "Mei-Lin is a CSS Working Group invited expert and the architect behind Roamly's responsive design system. She's been a leading voice in the container queries specification process and has helped ship container query-based layouts to production.", "Roamly", "Mei-Lin", "Staff Engineer", "Zhang", "" });

            migrationBuilder.InsertData(
                table: "Speaker",
                columns: new[] { "Id", "Biography", "Company", "FirstName", "IsFeatured", "JobTitle", "LastName", "ProfileImage" },
                values: new object[] { 5, "Priya works on the developer relations team at Cobalt, focusing on accessibility tooling and standards education. She created the popular 'A11y Myths Busted' video series and contributes to the browser's accessibility auditing rules.", "Cobalt", "Priya", true, "Senior Developer Advocate", "Sharma", "" });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "Id", "Color", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "#B5E9FC", "Opening and closing sessions", "Keynote" },
                    { 2, "#FFE6BA", "Building modern interfaces for the web", "Frontend" },
                    { 3, "#FEC9C3", "Make every millisecond count", "Performance" },
                    { 4, "#BBD8FF", "Building inclusive experiences for everyone", "Accessibility" },
                    { 5, "#CCC4FD", "Level up your developer workflow", "Tooling" }
                });

            migrationBuilder.InsertData(
                table: "Talk",
                columns: new[] { "Id", "ConferenceId", "Description", "EndDateTime", "IsKeynote", "RoomId", "SpeakerId", "StartDateTime", "Title", "TrackId" },
                values: new object[] { 1, 1, "The opening keynote. Elena takes the audience on a tour of the web platform's most transformative recent additions — from WebGPU to View Transitions to baseline support for container queries. She live-demos a full-stack application running entirely in the browser and makes the case that the gap between native and web has never been smaller.", new DateTime(2026, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 1, new DateTime(2026, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "The Next Frontier of Web Development", 1 });

            migrationBuilder.InsertData(
                table: "Talk",
                columns: new[] { "Id", "ConferenceId", "Description", "EndDateTime", "IsFeatured", "RoomId", "SpeakerId", "StartDateTime", "Title", "TrackId" },
                values: new object[] { 2, 1, "Modern video compression on the web is stuck between bloated codecs and unacceptable quality tradeoffs. Dinesh presents Pied Piper's middle-out compression approach adapted for browser-based video delivery — achieving dramatically better compression ratios without sacrificing visual fidelity.", new DateTime(2026, 11, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 2, new DateTime(2026, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "Video Compression for the Web: The Middle-Out Approach", 3 });

            migrationBuilder.InsertData(
                table: "Talk",
                columns: new[] { "Id", "ConferenceId", "Description", "EndDateTime", "RoomId", "SpeakerId", "StartDateTime", "Title", "TrackId" },
                values: new object[] { 3, 1, "Cartwell's frontend monorepo contains over 500 packages, dozens of apps, and is contributed to by 300+ engineers daily. James shares the hard-won lessons from building and maintaining this system — from dependency management and build caching to code ownership and migration strategies.", new DateTime(2026, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2026, 11, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), "Monorepos at Scale: Lessons from 500 Packages", 5 });

            migrationBuilder.InsertData(
                table: "Talk",
                columns: new[] { "Id", "ConferenceId", "Description", "EndDateTime", "IsFeatured", "RoomId", "SpeakerId", "StartDateTime", "Title", "TrackId" },
                values: new object[] { 4, 1, "Container queries have shipped in every major browser, but adoption in production remains low. Mei-Lin shares Roamly's journey of replacing hundreds of JavaScript-based responsive components with pure CSS container queries.", new DateTime(2026, 11, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 4, new DateTime(2026, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "CSS Container Queries in Production", 2 });

            migrationBuilder.InsertData(
                table: "Talk",
                columns: new[] { "Id", "ConferenceId", "Description", "EndDateTime", "RoomId", "SpeakerId", "StartDateTime", "Title", "TrackId" },
                values: new object[] { 5, 1, "Well-intentioned ARIA usage often makes interfaces less accessible, not more. Priya walks through the most commonly misused ARIA roles and properties — live regions that fire too often, menu roles on navigation, dialog traps that trap too much — and shows how to audit and fix them.", new DateTime(2026, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, new DateTime(2026, 11, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "ARIA Patterns You're Probably Using Wrong", 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Talk",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Conference",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Speaker",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
