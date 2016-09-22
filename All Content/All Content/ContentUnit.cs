using MySql.Data.MySqlClient;
using System; //екеар
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace All_Content
{
    class ContentUnit
    {
        DBClient client;
        static public int ID { get; private set; }
        public string header { get; set; }
        public string description { get; set; }
        public string imgUrl { get; set; }
        public string URL { get; set; }
        public string tags { get; set; }
        public string source { get; set; }

        public ContentUnit()
        {
            MySqlConnectionStringBuilder sqlStrBuilder = new MySqlConnectionStringBuilder();
            sqlStrBuilder.Server = "localhost";
            sqlStrBuilder.Database = "work_db";
            sqlStrBuilder.UserID = "root";
            sqlStrBuilder.Password = "Gonnadown";
            client = new DBClient(sqlStrBuilder);
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadContentToSQL()
        {
            ID = Convert.ToInt32(client.SelectQuery("SELECT MAX(id) AS id FROM content")[0]);
            ID++;
            client.Query("INSERT INTO content VALUES('" + ID + "','" + header + "','" + description + "', '" + imgUrl + "', '"
            + URL + "','" + tags + "','" + source + "');");
        }
    }
}
