using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace TwitchBot
{
    [Flags]
    public enum Statuses : uint
    {
        begruessen = 0x01,
        verdoppeln = 0x02,
    }

    public partial class Database
    {
        private static SQLiteConnection _conn = null;

        public static void Connect(string path)
        {
            _conn = new SQLiteConnection($"Data Source={path};Version=3;");
            _conn.Open();
        }

        public static void Disconnect()
        {
            _conn.Close();
        }
        
        public static uint GetUInt(string table, string selector, string whereCol, string whereVal)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT {selector} FROM {table} WHERE {whereCol} = @name";
                cmd.Parameters.Add(new SQLiteParameter("@name", whereVal));
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return 0;

                uint val = 0;
                if (reader.Read())
                    val = Convert.ToUInt32(reader[selector]);

                reader.Close();
                return val;
            }
            catch (SQLiteException ex)
            {
                // print error
                return 0;
            }
        }
        // gets Integer of the Row (whereval e.g. level, exp) from table from name "wherecol"
        public static int GetInt(string table, string selector, string whereCol, string whereVal)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT {selector} FROM {table} WHERE {whereCol} = @name";
                cmd.Parameters.Add(new SQLiteParameter("@name", whereVal));
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return 0;
                int val = 0;
                if (reader.Read())
                    val = Convert.ToInt32(reader[selector]);

                reader.Close();
                return val;
            }
            catch (SQLiteException ex)
            {
                // print error
                return 0;
            }
        }

        public static string GetString(string table, string selector, string whereCol, string whereVal)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT {selector} FROM {table} WHERE {whereCol} = @name";
                cmd.Parameters.Add(new SQLiteParameter("@name", whereVal));
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return "";
                string val = "";
                if (reader.Read())
                    val = Convert.ToString(reader[selector]);

                reader.Close();
                return val;
            }
            catch (SQLiteException ex)
            {
                // print error
                return ex.ToString();
            }
        }

        public static void UpdateColumn<T>(string table, string column, T val, string whereCol, string whereVal)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"UPDATE {table} SET {column}=@param WHERE {whereCol}=@name";
                cmd.Parameters.Add(new SQLiteParameter("@param", val));
                cmd.Parameters.Add(new SQLiteParameter("@name", whereVal));
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                // print error
            }
        }

        public static void DeleteRow(string table, string whereCol, string whereVal)
        {
            try
            {
                SQLiteCommand cmd = _conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"DELETE FROM {table} WHERE {whereCol}=@name";
                cmd.Parameters.Add(new SQLiteParameter("@name", whereVal));
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                // print error
            }
        }
    }
}
