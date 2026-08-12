using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // ==========================================
            // 1. CONFERENCE DATA
            // ==========================================
            modelBuilder.Entity<Conference>().HasData(
                new Conference
                {
                    Id = 1,
                    Name = "DevHorizon 2026",
                    Tagline = "where code meets the machine_",
                    Description = "The premier developer conference.",
                    StartDate = new DateOnly(2026, 11, 15),
                    EndDate = new DateOnly(2026, 11, 17),
                    Venue = "Pier 70",
                    City = "San Francisco",
                    StateOrProvince = "CA",
                    Country = "USA"
                }
            );
            // ==========================================
            // 2. ROOM DATA
            // ==========================================
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Room A", Capacity = 300 },
                new Room { Id = 2, Name = "Room B", Capacity = 250 },
                new Room { Id = 3, Name = "Room C", Capacity = 150 },
                new Room { Id = 4, Name = "Room D", Capacity = 150 }
            );
            // ==========================================
            // 3. TRACK DATA
            // ==========================================
            modelBuilder.Entity<Track>().HasData(
                new Track
                {
                    Id = 1,
                    Name = "Keynote",
                    Description = "Opening and closing sessions",
                    Color = "#B5E9FC"
                },
                new Track
                {
                    Id = 2,
                    Name = "Frontend",
                    Description = "Building modern interfaces for the web",
                    Color = "#FFE6BA"
                },
                new Track
                {
                    Id = 3,
                    Name = "Performance",
                    Description = "Make every millisecond count",
                    Color = "#FEC9C3"
                },
                new Track
                {
                    Id = 4,
                    Name = "Accessibility",
                    Description = "Building inclusive experiences for everyone",
                    Color = "#BBD8FF"
                },
                new Track
                {
                    Id = 5,
                    Name = "Tooling",
                    Description = "Level up your developer workflow",
                    Color = "#CCC4FD"
                }
            );
            // ==========================================
            //4. SPEAKER DATA
            // ==========================================
            modelBuilder.Entity<Speaker>().HasData(
                new Speaker
                {
                    Id = 1,
                    FirstName = "Elena",
                    LastName = "Vasquez",
                    JobTitle = "Principal Frontend Engineer",
                    Company = "Bytecraft",
                    Biography = "Elena has spent the last decade pushing the boundaries of in-browser development environments. She led the browser-native IDE initiative at Bytecraft and is a frequent contributor to the TC39 process. Her work focuses on making the web platform a first-class development target.",
                    ProfileImage = "",
                    IsFeatured = true
                },
                new Speaker
                {
                    Id = 2,
                    FirstName = "Dinesh",
                    LastName = "Chugtai",
                    JobTitle = "Senior Frontend Engineer",
                    Company = "Pied Piper",
                    Biography = "Dinesh is a senior frontend engineer at Pied Piper, where he led the development of the Pied Piper video chat platform and the consumer-facing web interface. He specializes in real-time video compression on the client side and has deep experience with WebRTC, codec optimization, and building performant media experiences in the browser.",
                    ProfileImage = "",
                    IsFeatured = false
                },
                new Speaker
                {
                    Id = 3,
                    FirstName = "James",
                    LastName = "Okonkwo",
                    JobTitle = "Engineering Director",
                    Company = "Cartwell",
                    Biography = "James oversees Cartwell's frontend platform team, managing the monorepo that powers thousands of internal and merchant-facing applications. He's a vocal advocate for developer experience as a product concern and has led the company's migration to a unified build system serving over 300 engineers.",
                    ProfileImage = "",
                    IsFeatured = true
                },
                new Speaker
                {
                    Id = 4,
                    FirstName = "Mei-Lin",
                    LastName = "Zhang",
                    JobTitle = "Staff Engineer",
                    Company = "Roamly",
                    Biography = "Mei-Lin is a CSS Working Group invited expert and the architect behind Roamly's responsive design system. She's been a leading voice in the container queries specification process and has helped ship container query-based layouts to production.",
                    ProfileImage = "",
                    IsFeatured = false
                },
                new Speaker
                {
                    Id = 5,
                    FirstName = "Priya",
                    LastName = "Sharma",
                    JobTitle = "Senior Developer Advocate",
                    Company = "Cobalt",
                    Biography = "Priya works on the developer relations team at Cobalt, focusing on accessibility tooling and standards education. She created the popular 'A11y Myths Busted' video series and contributes to the browser's accessibility auditing rules.",
                    ProfileImage = "",
                    IsFeatured = true
                }
            );
            // ==========================================
            // 5. TALK DATA
            // ==========================================
            modelBuilder.Entity<Talk>().HasData(
                new Talk
                {
                    Id = 1,
                    ConferenceId = 1,
                    TrackId = 1, // Keynote
                    RoomId = 1,  // Room A
                    SpeakerId = 1, // Elena Vasquez
                    Title = "The Next Frontier of Web Development",
                    Description = "The opening keynote. Elena takes the audience on a tour of the web platform's most transformative recent additions — from WebGPU to View Transitions to baseline support for container queries. She live-demos a full-stack application running entirely in the browser and makes the case that the gap between native and web has never been smaller.",
                    StartDateTime = new DateTime(2026, 11, 15, 9, 0, 0),
                    EndDateTime = new DateTime(2026, 11, 15, 10, 0, 0),
                    IsFeatured = false,
                    IsKeynote = true
                },
                new Talk
                {
                    Id = 2,
                    ConferenceId = 1,
                    TrackId = 3, // Performance
                    RoomId = 2,  // Room B
                    SpeakerId = 2, // Dinesh Chugtai
                    Title = "Video Compression for the Web: The Middle-Out Approach",
                    Description = "Modern video compression on the web is stuck between bloated codecs and unacceptable quality tradeoffs. Dinesh presents Pied Piper's middle-out compression approach adapted for browser-based video delivery — achieving dramatically better compression ratios without sacrificing visual fidelity.",
                    StartDateTime = new DateTime(2026, 11, 15, 11, 0, 0),
                    EndDateTime = new DateTime(2026, 11, 15, 12, 0, 0),
                    IsFeatured = true,
                    IsKeynote = false
                },
                new Talk
                {
                    Id = 3,
                    ConferenceId = 1,
                    TrackId = 5, // Tooling
                    RoomId = 4,  // Room D
                    SpeakerId = 3, // James Okonkwo
                    Title = "Monorepos at Scale: Lessons from 500 Packages",
                    Description = "Cartwell's frontend monorepo contains over 500 packages, dozens of apps, and is contributed to by 300+ engineers daily. James shares the hard-won lessons from building and maintaining this system — from dependency management and build caching to code ownership and migration strategies.",
                    StartDateTime = new DateTime(2026, 11, 15, 12, 0, 0),
                    EndDateTime = new DateTime(2026, 11, 15, 13, 0, 0),
                    IsFeatured = false,
                    IsKeynote = false
                },
                new Talk
                {
                    Id = 4,
                    ConferenceId = 1,
                    TrackId = 2, // Frontend
                    RoomId = 1,  // Room A
                    SpeakerId = 4, // Mei-Lin Zhang
                    Title = "CSS Container Queries in Production",
                    Description = "Container queries have shipped in every major browser, but adoption in production remains low. Mei-Lin shares Roamly's journey of replacing hundreds of JavaScript-based responsive components with pure CSS container queries.",
                    StartDateTime = new DateTime(2026, 11, 15, 13, 0, 0),
                    EndDateTime = new DateTime(2026, 11, 15, 14, 0, 0),
                    IsFeatured = true,
                    IsKeynote = false
                },
                new Talk
                {
                    Id = 5,
                    ConferenceId = 1,
                    TrackId = 4, // Accessibility
                    RoomId = 3,  // Room C
                    SpeakerId = 5, // Priya Sharma
                    Title = "ARIA Patterns You're Probably Using Wrong",
                    Description = "Well-intentioned ARIA usage often makes interfaces less accessible, not more. Priya walks through the most commonly misused ARIA roles and properties — live regions that fire too often, menu roles on navigation, dialog traps that trap too much — and shows how to audit and fix them.",
                    StartDateTime = new DateTime(2026, 11, 15, 15, 0, 0),
                    EndDateTime = new DateTime(2026, 11, 15, 16, 0, 0),
                    IsFeatured = false,
                    IsKeynote = false
                }
            );
        }
    }
}
