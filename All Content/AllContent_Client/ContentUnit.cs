using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllContent_Client
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


        public ContentUnit()
        {
            client = new DBClient();
        }

         

    }
}
