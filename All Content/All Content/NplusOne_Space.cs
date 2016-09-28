using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using System.Windows;


namespace All_Content 
{
    class NplusOne_Space : SiteForPars 
    {
        const int news_limit = 6;
      
        public NplusOne_Space() : base ("https://nplus1.ru/rubric/space")
        {
            
            
        }

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            var all_news = document.All.Where(m => m.Id == "main").First().QuerySelectorAll("div.caption");

            int count = 0;
            foreach (IElement element in all_news)
            {
                cu.header = element.QuerySelector("h3").TextContent;
                cu.description = element.QuerySelector("h3").TextContent;
                cu.URL = link + element.ParentElement.GetAttribute("href");
                cu.imgUrl = "";
                cu.source = link;
                cu.tags = "since;space;";
                cu.LoadContentToSQL();
                count++;
                if (count == news_limit)
                    break;
            }
        }
    }
}
