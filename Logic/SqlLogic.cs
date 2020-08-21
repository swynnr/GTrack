using GTrack.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTrack.Logic
{
    public static class SqlLogic
    {
        public static List<TarkovStats> LoadData(string sql)
        {
            List<TarkovStats> list = new List<TarkovStats>();

            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            using (MySqlConnection conn = GetConnection()) {
                conn.Open();
                using (var reader = (new MySqlCommand(sql, conn)).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TarkovStats()
                        {
                            kill = reader["kill"].ToString(),
                            death = reader["death"].ToString(),
                            count = Convert.ToInt32(reader["count"]),
                            id = Convert.ToInt32(reader["id"])
                        });
                    }
                    
                }
                conn.Close();
            }
            return list;
        }

        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection("server=localhost; database=friendstat; user=root; password=root; Charset=utf8;");
        }

        public static void Counter(string sql)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
