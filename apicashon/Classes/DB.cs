using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.Http.Headers;
using apicashon.Classes.models;

namespace apicashon.Classes
{
    internal class DB
    {
        private static MySqlConnection _connection;
        private static string _server;
        private static string _uid;
        private static string _pwd;
        private static string _database;

        private static DB _instance;

        private static string _connectionString;

        private static void CheckInstance()
        {
            if (_instance == null)
            {
                _instance = new DB();
            }
        }
        public static void Open()
        {
            CheckInstance();
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("err " + ex);
            }
        }

        public static MySqlCommand Command(string query)
        {
            return new MySqlCommand(query, _connection);
        }

        public static void Close()
        {
            CheckInstance();
            try
            {
            _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("err " + ex);
            }
        }

        private DB()
        {
            _server = "127.0.0.1";
            _uid = "root";
            _pwd = "";
            _database = "agr2";

            _connectionString = $"server={_server};uid={_uid};pwd={_pwd};database={_database}";
            _connection = new MySqlConnection(_connectionString);
        }
    }
}
