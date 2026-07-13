using MySqlConnector;

namespace Meraki_Project
{
    // Single place the connection string lives. Edit the password (and server/port
    // if MySQL isn't local) to match your MySQL installation.
    internal static class Db
    {
        public const string ConnectionString =
            "Server=localhost;Port=3306;Database=meraki;User ID=root;Password=1122;";

        public static MySqlConnection Open()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        // Called once at startup so a wrong password/server fails with a clear
        // message instead of a crash on the first query.
        public static void TestConnection()
        {
            using MySqlConnection conn = Open();
        }
    }
}
