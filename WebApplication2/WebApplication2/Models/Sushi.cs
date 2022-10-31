using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace WebApplication2.Models
{
    
    [Table("sushi")]
    public class Sushi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img_url { get; set; }
        public string Created_at { get; set; }
        public float Price { get; set; }
    }
}