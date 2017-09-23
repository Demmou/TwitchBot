using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace TwitchBot
{
    public partial class Database
    {
        
        public static void InsertNewUser(string name, UInt64 points, UInt64 experience, UInt64 minutesWatched)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CurrencyUser (Name, Points, Experience, MinutesWatched) VALUES (@name, @points, @experience, @minutesWatched)";
                cmd.Parameters.Add(new SQLiteParameter("@name", name));
                cmd.Parameters.Add(new SQLiteParameter("@points", points));
                cmd.Parameters.Add(new SQLiteParameter("@experience", experience));
                cmd.Parameters.Add(new SQLiteParameter("@minutesWatched", minutesWatched));
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                // print error
            }
        }

        public static bool UserExists(string name)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Name FROM CurrencyUser WHERE Name = @name";
                cmd.Parameters.Add(new SQLiteParameter("@name", name));
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return false;

                bool result = false;
                if (reader.Read())
                    result = true;

                reader.Close();
                return result;
            }
            catch (SQLiteException ex)
            {
                // print error
                return false;
            }
        }

        public static Dictionary<string /*user*/, int /*val*/> GetTop(string column, int num)
        {
            Dictionary<string /*user*/, int /*val*/> dict = new Dictionary<string /*user*/, int /*val*/>();
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT Name, {column} FROM CurrencyUser ORDER BY {column} DESC LIMIT {num} WHERE Name not like demmou AND horican AND demmoubot AND bot_horican AND nightbot";
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    dict.Add(Convert.ToString(reader["Name"]), int.Parse(reader[column].ToString()));

                reader.Close();
                return dict;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dict;
            }
        }

        public static void UpdatePoints(string name, int points) { UpdateColumn<int>("CurrencyUser", "Points", points, "Name", name); }
        public static int GetPoints(string name) { return GetInt("CurrencyUser", "Points", "Name", name); }
        public static void AddPoints(string name, int points) { UpdatePoints(name, GetPoints(name) + points); }

        public static void UpdateExperience(string name, int points) { UpdateColumn<int>("CurrencyUser", "Experience", points, "Name", name); }
        public static int GetExperience(string name) { return GetInt("CurrencyUser", "Experience", "Name", name); }
        public static void AddExperience(string name, int points) { UpdateExperience(name, GetExperience(name) + points); }

        public static void UpdateMinutesWatched(string name, int points) { UpdateColumn<int>("CurrencyUser", "MinutesWatched", points, "Name", name); }
        public static int GetMinutesWatched(string name) { return GetInt("CurrencyUser", "MinutesWatched", "Name", name); }
        public static void AddMinutesWatched(string name, int points) { UpdateMinutesWatched(name, GetMinutesWatched(name) + points); }

        public static void UpdateStatus(string name, uint status) { UpdateColumn<uint>("CurrencyUser", "Status", status, "Name", name); }
        public static uint GetStatus(string name) { return GetUInt("CurrencyUser", "Status", "Name", name); }
        
        public static bool HasStatus(string name, Statuses status) { return (GetStatus(name) & (uint)status) > 0; }
        public static void SetStatus(string name, Statuses status) { UpdateStatus(name, GetStatus(name) | (uint)status); }
        public static void RemoveStatus(string name, Statuses status) { UpdateStatus(name, GetStatus(name) & ~(uint)status); }

        // Upate = Set value
        //Getpoints = get value
        // AddColumn = adds Value on top of column
        // Database.HasStatus(username, Statuses.VERDOPPELN)
        // Database.SetStatus(username, Statuses.VERDOPPELN)
        // Database.RemoveStatus(username, Statuses.VERDOPPELN)
    }
}
