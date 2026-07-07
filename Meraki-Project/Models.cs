using System;
using System.Collections.Generic;

namespace Meraki_Project
{
    // Plain data holders the repositories fill from MySQL and the forms display.

    public class User
    {
        public int UserId;
        public string Role = "";
        public string FirstName = "";
        public string LastName = "";
        public string Email = "";
        public string Phone = "";
        public string Status = "";
        public DateTime CreatedAt;
        public byte[]? Photo;

        public string FullName => $"{FirstName} {LastName}".Trim();
    }

    public class BabysitterInfo
    {
        public int UserId;
        public string Name = "";
        public string Bio = "";
        public decimal HourlyRate;
        public int ExperienceYears;
        public string Location = "";
        public bool Verified;
        public bool Available;
        public double AvgRating;      // 0 when no reviews yet
        public int ReviewCount;
        public List<string> Skills = new();
    }

    public class BookingInfo
    {
        public int BookingId;
        public int ParentId;
        public int BabysitterId;
        public string ParentName = "";
        public string SitterName = "";
        public DateTime Date;
        public TimeSpan Start;
        public int DurationHours;
        public int ChildrenCount;
        public string Address = "";
        public string Notes = "";
        public string Status = "";
        public decimal HourlyRate;
        public decimal ServiceFee;
        public decimal Total;
        public bool HasReview;

        public TimeSpan End => Start + TimeSpan.FromHours(DurationHours);

        // "6:00 PM – 10:00 PM"
        public string TimeRangeText =>
            $"{DateTime.Today.Add(Start):h:mm tt} – {DateTime.Today.Add(End):h:mm tt}";

        // "6–10 PM" (short form for calendar cells)
        public string TimeRangeShort =>
            $"{DateTime.Today.Add(Start):h}–{DateTime.Today.Add(End):h tt}";
    }

    public class ReviewInfo
    {
        public string Author = "";
        public int Rating;
        public string Comment = "";
        public DateTime CreatedAt;
    }

    public class NotificationInfo
    {
        public int NotificationId;
        public string Message = "";
        public bool Unread;
        public DateTime CreatedAt;

        public string TimeAgoText
        {
            get
            {
                var span = DateTime.Now - CreatedAt;
                if (span.TotalMinutes < 60) return $"{Math.Max(1, (int)span.TotalMinutes)} min ago";
                if (span.TotalHours < 24) return $"{(int)span.TotalHours} hr{((int)span.TotalHours == 1 ? "" : "s")} ago";
                if (span.TotalDays < 2) return "Yesterday";
                return CreatedAt.ToString("MMM d");
            }
        }
    }
}
