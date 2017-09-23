using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace TwitchBot
{
    public partial class Database
    {
        public static void InsertNewCommand(string command, string Text)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CommandChat (command, commandText) VALUES (@command, @commandText)";
                cmd.Parameters.Add(new SQLiteParameter("@command", command));
                cmd.Parameters.Add(new SQLiteParameter("@commandText", Text));
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
        }

        public static void UpdateCommandText(string command, string text)
        {
            UpdateColumn<string>("CommandChat", "commandText", text, "command", command);
        }

        public static string GetCommandText(string command)
        {
            return GetString("CommandChat", "commandText", "command", command);
        }

        public static void DeleteCommand(string command)
        {
            DeleteRow("CommandChat", "command", command);
        }

        public static Dictionary<string /*command*/, string /*commandtext*/> GetCommands()
        {
            Dictionary<string /*command*/, string /*commandtext*/> dict = new Dictionary<string /*command*/, string /*commandtext*/>();
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT command, commandText FROM CommandChat";
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return null;

                while (reader.Read())
                    dict.Add(Convert.ToString(reader["command"]), Convert.ToString(reader["commandText"]));

                reader.Close();
                return dict;
            }
            catch (SQLiteException ex)
            {
                // print error
                return null;
            }
        }
    }
}
