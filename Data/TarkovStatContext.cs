using GTrack.Logic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;

namespace GTrack.Models
{
    public static class TarkovStatContext 
    {



        public static List<TarkovStats> GetTarkovStats()
        {
            return SqlLogic.LoadData("SELECT * FROM tarkov");
        }

        public static void IncrementCounter(int id)
        {
            SqlLogic.Counter("UPDATE tarkov " +
                             "SET count = count + 1 " +
                             "WHERE id = " + id + ';');
        }

    }
}
