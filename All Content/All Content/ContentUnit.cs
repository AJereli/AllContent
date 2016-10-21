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


        static uint R_limit;
        public static uint Row_limit
        {
            set
            {
                if (value >= 9000)
                    R_limit = 9000;
            }
            get
            {  lock(arch_lock)
                    return R_limit;
            }
        }

        private static int curr_news_cnt = 0;

        public int ID { get; private set; }
        public string header { get; set; }
        public string description { get; set; }
        public string imgUrl { get; set; }
        public string URL { get; set; }
        public string tags { get; set; }
        public string source { get; set; }
        public string date { get; set; }

        public DateTime time_of_addition { get; private set; }


        private static object arch_lock = new object();
        private object This;
        public ContentUnit()
        {
            
            client = new DBClient();
            date = header = imgUrl = description = URL = tags = source = "";
            This = this;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool LoadContentToSQL()
        {
           
            CheckForOF(this);

            if (ContainsNote())
                return false;

            time_of_addition = DateTime.Now;



            client.Query("INSERT INTO content (header, description, imgUrl, URL, tags, source, date, time_of_addition)"
           + "VALUES(@header, @description, @imgUrl, @URL, @tags, @source, @date, @time_of_addition)", this);




            return true;
        }

        private static void CheckForOF(ContentUnit cu_this)
        {

            curr_news_cnt++;

            if (curr_news_cnt == Row_limit)
                Archive(cu_this);
        }

        private static void Archive(ContentUnit cu_this)
        {
            cu_this.client.Query("INSERT INTO content_arch (header, description, imgUrl, URL, tags, source, date, time_of_addition)"
           + "SELECT * FROM content");
            cu_this.client.Query("DELETE FROM content");
        }

        bool ContainsNote()
        {
            if (client.SelectQuery("SELECT id FROM content WHERE URL = '" + URL + "';").Count > 0)
                return true;
            else return false;

        }
    }
}
