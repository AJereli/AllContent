using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using System.Windows.Threading;
using System.Windows;

namespace All_Content
{
    class NplusOne : SiteForPars
    {
        List<SiteForPars> all_no;
        public NplusOne() : base("https://nplus1.ru")
        {
            all_no = new List<SiteForPars>();
            all_no.Add(new NplusOne_Space());
            all_no.Add(new NplusOne_ScienceBitch());
            all_no.Add(new NplusOne_Gadgets());
        }
        public override void Pars()
        {
            foreach (var nplus in all_no)
                nplus.Pars();
        }

    }
    class NplusOne_Space : SiteForPars
    {
        const int news_limit = 6;

        public NplusOne_Space() : base("https://nplus1.ru/rubric/space")
        {


        }

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            var all_news = document.All.Where(m => m.Id == "main").First().QuerySelectorAll("article.item.item-news.item-news-._exist-image div.caption");

           // int count = 0;
            foreach (IElement element in all_news)
            {
                cu.header = element.QuerySelector("h3").TextContent;
                cu.description = element.QuerySelector("h3").TextContent;
                cu.URL = link + element.ParentElement.GetAttribute("href");
                cu.imgUrl = "";
                cu.source = link;
                cu.tags = "since;space;";
                cu.LoadContentToSQL();
             //   count++;
               // if (count == news_limit)
                 //   break;
            }
        }
    }
    class NplusOne_ScienceBitch : SiteForPars
    {
        public NplusOne_ScienceBitch() : base("https://nplus1.ru/rubric/science")
        {


        }

        public override void Pars()
        {
         

            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            var all_news = document.All.Where(m => m.Id == "main").First().QuerySelectorAll("article.item.item-news.item-news-._exist-image div.caption");
            foreach(IElement element in all_news)
            {
                cu.header = element.QuerySelector("h3").TextContent;
                cu.description = element.QuerySelector("h3").TextContent;
                cu.URL = link + element.ParentElement.GetAttribute("href");
                cu.imgUrl = "";
                cu.source = link;
                cu.tags = "science;n+1";
                cu.LoadContentToSQL();                        
                 
            }
           
        }
    }
    class NplusOne_Gadgets : SiteForPars
    {
        public NplusOne_Gadgets() : base("https://nplus1.ru/rubric/gadgets")
        {


        }

        public override void Pars()
        {
           // const int limit = 6;
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            var all_news = document.All.Where(m => m.Id == "main").First().QuerySelectorAll("article.item.item-news.item-news-._exist-image div.caption");
          //  int cnt = 0;
            foreach (IElement element in all_news)
            {
                cu.header = element.QuerySelector("h3").TextContent;
                cu.description = element.QuerySelector("h3").TextContent;
                cu.URL = link + element.ParentElement.GetAttribute("href");
                cu.imgUrl = "";
                cu.source = link;
                cu.tags = "gadgets;n+1";
                cu.LoadContentToSQL();
                //cnt++;
              //  if (cnt == limit)
                //    break;
            }

        }
    } 
}
