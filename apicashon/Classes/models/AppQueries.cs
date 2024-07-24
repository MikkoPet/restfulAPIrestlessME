using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace apicashon.Classes.models
{
    internal class AppQueries
    {


        public static byte[] GetAll(string query)
        {
            DB.Open();
            MySqlCommand command = DB.Command(query);

            List<Production> productions = new List<Production>();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32("id_production");
                string name = reader.GetString("nom_production");
                string unit = reader.GetString("unite");


                productions.Add(new Production(id, name, unit));
            }


            string resJson = JsonSerializer.Serialize(productions);

            return Encoding.UTF8.GetBytes(resJson);
        }

        public static byte[] GetByID(string query, int id)
        {
            DB.Open();

            MySqlCommand command = DB.Command(query);
            command.Parameters.AddWithValue("@id_production", id);

            Production data;

            MySqlDataReader reader = command.ExecuteReader();
            
            
                int idOut = reader.GetInt32("id_production");
                string name = reader.GetString("nom_production");
                string unit = reader.GetString("unite");

                data = new Production(idOut, name, unit);
            

            string resJson = JsonSerializer.Serialize(data);

            return Encoding.UTF8.GetBytes(resJson);
        }


        private AppQueries ()
        {

        }

    }
}
