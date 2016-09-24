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
    class TheVillagePars : SiteForPars
    {
        

        public TheVillagePars()
        {
            link = "http://www.the-village.ru/";

            cu = new ContentUnit();
            parser = new HtmlParser();
            config = Configuration.Default.WithDefaultLoader();
            document = BrowsingContext.New(config).OpenAsync(link).Result;
            var all_news = document.All.Where(m => m.Id == "widget_news_block").First().QuerySelectorAll("div.post-item.post-item-news a");

            foreach (IElement element in all_news)
            {
                cu.URL = link + element.GetAttribute("href");
                cu.header = element.QuerySelector("h3").TextContent;
                cu.source = link;
                cu.description = cu.header;
                cu.imgUrl = "";
                cu.tags = "TheVillage";
                cu.LoadContentToSQL();
            }
        }
    }
}
