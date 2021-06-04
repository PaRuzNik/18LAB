using Microsoft.Data.SqlClient;
using System;

namespace ConsoleApp2
{
    class App2
    {
        public static string ConnStr = @"Data Source=PASHACOMP;Integrated Security=True;
            Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            int ID = 0;
            using (var connection = new SqlConnection(ConnStr))
            {
                connection.Open();
                using (var cmd2 = new SqlCommand($"SELECT MAX(id) FROM [Lab18].[dbo].[Persons]", connection))
                {
                    using (var rd = cmd2.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            ID = Convert.ToInt32(rd.GetValue(0));
                        }
                    }
                }
                connection.Close();
            }

            SqlConnection cn = new SqlConnection(ConnStr);
            SqlCommand cmd;
            cn.Open();
            cmd = cn.CreateCommand();

            cmd.CommandText = $"INSERT INTO [Lab18].[dbo].[Persons] VALUES({ID+1},'Vikor', 'Shekhovtsov', '20.10.2001')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = $"INSERT INTO [Lab18].[dbo].[Animals] VALUES({ID + 1},'Cat', 'Igor')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = $"INSERT INTO [Lab18].[dbo].[CarPrices] VALUES({ID + 1},'Audi', '100000', '17.06.1995')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = $"INSERT INTO [Lab18].[dbo].[HomeLists] VALUES({ID + 1},'222BC', '6', '18000')";
            cmd.ExecuteNonQuery();

            cmd.CommandText = $"INSERT INTO [Lab18].[dbo].[Journeys] VALUES({ID + 1},'Earth', 'Mars', '5 Years 6 months 4 Day 5 Hours 36 Minutes 5 Seconds')";
            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}
