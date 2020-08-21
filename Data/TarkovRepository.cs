using GTrack.Logic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;
using Newtonsoft.Json.Linq;


namespace GTrack.Models
{
    public static class TarkovRepository 
    {



        public static List<TarkovStats> GetTarkovStats()
        {
            try 
            {
                var list = new List<TarkovStats>();

                var reader =  (MySqlDataReader)TarkovDao.LoadData();
                
                while(reader.Read()){
                    list.Add(new TarkovStats()
                    {
                        kill = reader["kill"].ToString(),
                        death = reader["death"].ToString(),
                        count = Convert.ToInt32(reader["count"]),
                        id = Convert.ToInt32(reader["id"])
                    });
                }

                return list;    
            }   
            
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                return null;
            }
        }

        public static void IncrementCounter(int id)
        {
            TarkovDao.Counter("UPDATE tarkov " +
                             "SET count = count + 1 " +
                             "WHERE id = " + id + ';');
        }

    }
}
