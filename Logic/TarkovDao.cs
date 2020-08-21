using GTrack.Data;
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
    public static class TarkovDao
    {
        public static object LoadData()
        {
            Query query = new Query("Server=localhost; Database=friendstat; Uid=root; Pwd=root;");
            return query.GetReader("SELECT * FROM tarkov");
        }

        public static void Counter(string sql)
        {
            Query query = new Query("Server=localhost; Database=friendstat; Uid=root; Pwd=root;");
            query.ExecuteNonQuery(sql); 
        }
    }
}


