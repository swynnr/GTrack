using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTrack.Data
{
    public class Query
    {   
        private MySqlConnection connection = null;
        public Query(string _connectionString)
        {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            try
            {
                connection = new MySqlConnection(_connectionString);
                connection.Open();

            }
            catch (MySqlException e)
            {
                throw e;
            }

        }
        public MySqlDataReader GetReader(string sql)
        {
            try
            {
                var cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            try
            {
                var cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public string InjectionSanitizer(string cmd)
        {
            cmd = MySql.Data.MySqlClient.MySqlHelper.EscapeString(cmd);
            return cmd;
        }
    }
}
