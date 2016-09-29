using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

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
        public string date { get; set; }

        public DateTime time_of_addition { get; private set; }
        public ContentUnit()
        {
            client = new DBClient();
            date = header = imgUrl = description = URL = tags = source = "";
        }
        /// <summary>
        /// 
        /// </summary>
        public bool LoadContentToSQL()
        {
            if (ContainsNote())
                return false;

            time_of_addition = DateTime.Now;



            client.Query("INSERT INTO content (header, description, imgUrl, URL, tags, source, date, time_of_addition)"
           + "VALUES(@header, @description, @imgUrl, @URL, @tags, @source, @date, @time_of_addition)", this);



            return true;
        }


        bool ContainsNote()
        {
            if (client.SelectQuery("SELECT id FROM content WHERE URL = '" + URL + "';").Count > 0)
                return true;
            else return false;

        }
    }
}
