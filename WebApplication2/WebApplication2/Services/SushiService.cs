using System.Collections.Generic;
using System.Linq;
using WebApplication2.Db;
using WebApplication2.Interface;
using WebApplication2.Models;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace WebApplication2.Services
{
    public class SushiServices : ISushiService
    {
        private readonly SushiDb db;

        public SushiServices(SushiDb db)
        {
            this.db = db;
        }


        public List<Sushi> GetSushis()
        {
            Console.WriteLine("Hello Testing");
            var sushis = new List<Sushi>(); 
            /*var sushis1 = db.SushisDb.Select(x => new Sushi()
            {     
                Id = x.Id,
                Name = x.Name,
                Img_url = x.Img_url,
                Created_at = x.Created_at,
                Price = x.Price
            }).ToList();
            Console.WriteLine(sushis1);*/
            string constr = "Data Source=localhost;port=3306;Initial Catalog=sushi_db;User Id=root;password=";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM sushi order by id;";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sushis.Add(new Sushi
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = sdr["Name"].ToString(),
                                Img_url = sdr["Img_url"].ToString(),
                                Created_at = sdr["Created_at"].ToString(),
                                Price = Convert.ToInt64(sdr["Price"]),
                            });
                        }
                    }
                    con.Close();
                }
            }
            return sushis;
        }
    }
}
