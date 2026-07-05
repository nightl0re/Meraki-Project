using System.Collections.Generic;
using System.Drawing;

namespace Meraki_Project
{
    // Shared "babysitter" shape used by both SearchBabysitterForm and BookingForm so
    // the two pages agree on the same people.
    // TODO (Phase 2): delete this file - both forms will instead query
    // `babysitter_profiles` (joined with `users` and `babysitter_skills`).
    public sealed class Babysitter
    {
        public int Id;
        public string Name = "";
        public int Age;
        public int ExperienceYears;
        public double Rating;
        public int ReviewCount;
        public double HourlyRate;
        public string Location = "";
        public bool Available;
        public string Bio = "";
        public string[] Tags = System.Array.Empty<string>();
        public string Avatar = "";
        public Color Color;
        public bool Verified;
    }

    internal static class MockData
    {
        public static readonly List<Babysitter> Babysitters = new()
        {
            new Babysitter
            {
                Id = 1, Name = "Emma Thompson", Age = 24, ExperienceYears = 3, Rating = 4.9, ReviewCount = 47,
                HourlyRate = 18, Location = "Downtown", Available = true,
                Bio = "Certified in first aid. Loves arts & crafts.",
                Tags = new[] { "Infants", "Toddlers", "Arts & Crafts" }, Avatar = "E",
                Color = Color.FromArgb(94, 200, 196), Verified = true,
            },
            new Babysitter
            {
                Id = 2, Name = "Mia Rodriguez", Age = 22, ExperienceYears = 2, Rating = 4.7, ReviewCount = 31,
                HourlyRate = 16, Location = "Midtown", Available = true,
                Bio = "Early childhood education student. Bilingual.",
                Tags = new[] { "School Age", "Bilingual", "Homework Help" }, Avatar = "M",
                Color = Color.FromArgb(244, 168, 124), Verified = true,
            },
            new Babysitter
            {
                Id = 3, Name = "Sarah Park", Age = 28, ExperienceYears = 5, Rating = 5.0, ReviewCount = 92,
                HourlyRate = 22, Location = "Uptown", Available = false,
                Bio = "Former teacher with 5 years of experience.",
                Tags = new[] { "Infants", "Special Needs", "CPR Certified" }, Avatar = "S",
                Color = Color.FromArgb(232, 113, 74), Verified = true,
            },
            new Babysitter
            {
                Id = 4, Name = "Claire Johnson", Age = 21, ExperienceYears = 1, Rating = 4.6, ReviewCount = 18,
                HourlyRate = 15, Location = "Westside", Available = true,
                Bio = "Pediatric nursing student. Gentle and patient.",
                Tags = new[] { "Toddlers", "School Age" }, Avatar = "C",
                Color = Color.FromArgb(224, 90, 90), Verified = false,
            },
            new Babysitter
            {
                Id = 5, Name = "Lily Chen", Age = 26, ExperienceYears = 4, Rating = 4.8, ReviewCount = 63,
                HourlyRate = 20, Location = "Eastside", Available = true,
                Bio = "Music teacher who brings creativity to every session.",
                Tags = new[] { "Music", "Infants", "Toddlers" }, Avatar = "L",
                Color = Color.FromArgb(255, 209, 102), Verified = true,
            },
            new Babysitter
            {
                Id = 6, Name = "Natalie Brooks", Age = 23, ExperienceYears = 2, Rating = 4.5, ReviewCount = 22,
                HourlyRate = 16, Location = "Downtown", Available = false,
                Bio = "Loves outdoor activities and nature walks with kids.",
                Tags = new[] { "Outdoors", "School Age", "Sports" }, Avatar = "N",
                Color = Color.FromArgb(94, 200, 196), Verified = false,
            },
        };
    }
}
