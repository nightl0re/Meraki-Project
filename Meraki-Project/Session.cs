using System;

namespace Meraki_Project
{
    // Which kind of account is currently signed in. Drives which dashboard
    // Login sends the user to and which navbar links each form shows.
    public enum UserRole
    {
        Parent,
        Babysitter,
        Admin
    }

    // Tiny in-memory "who's logged in" holder shared by every form.
    //
    // Phase 1 (now): filled in by LoginForm/RegisterForm with whatever the user typed,
    // no real authentication yet.
    // Phase 2 (after the database exists): LoginForm will populate this from the real
    // `users` row returned by the credential check, including a real UserId used for
    // every booking/review/favorite/notification query.
    internal static class Session
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentUserName { get; set; } = "";
        public static string CurrentUserEmail { get; set; } = "";
        public static UserRole CurrentRole { get; set; } = UserRole.Parent;

        public static void Clear()
        {
            CurrentUserId = 0;
            CurrentUserName = "";
            CurrentUserEmail = "";
            CurrentRole = UserRole.Parent;
        }

        // "jane.doe@email.com" -> "Jane.doe" - just for a friendly greeting until
        // real first/last name columns are wired up in Phase 2.
        public static string DeriveDisplayName(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return "User";
            string local = email.Split('@')[0];
            if (local.Length == 0) return "User";
            return char.ToUpper(local[0]) + local.Substring(1);
        }
    }
}
