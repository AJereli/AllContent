using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace All_Content
{
    class LentaRu : SiteForPars
    {
        public LentaRu() : base("https://lenta.ru")
        {
            
            var main_new = document.QuerySelector("div.row div.span8 div.first-item");
            cu.header = main_new.QuerySelector("h2").TextContent;
            cu.imgUrl = main_new.QuerySelector("a img").GetAttribute("src");
            cu.URL = link + main_new.QuerySelector("h2 a").GetAttribute("href");
            cu.description = main_new.QuerySelector("div.announce").TextContent;
            cu.LoadContentToSQL();

            foreach (var el in document.QuerySelectorAll("div.row div.span4 div.items div.item"))
            {
                cu.header = el.QuerySelector("a").TextContent;
                cu.imgUrl = "";
                cu.URL = link + el.QuerySelector("a").GetAttribute("href");
                cu.description = "";
                cu.date = el.QuerySelector("time").GetAttribute("datetime");
                cu.LoadContentToSQL();
            }
            var footer_content = document.QuerySelector("div.row div.span8 div.row.js-content");
            foreach (var el in footer_content.QuerySelectorAll("div.item.article"))
            {
                cu.header = el.QuerySelector("div.titles h3").TextContent;
                cu.imgUrl = el.QuerySelector("img.g-picture").GetAttribute("src");
                cu.URL = link + el.QuerySelector("a.js-dh.picture").GetAttribute("href");
                cu.description = el.QuerySelector("div.rightcol").TextContent;
                cu.tags = el.QuerySelector("div.info.g-date.item__info a").TextContent;
                cu.date = "";
                cu.LoadContentToSQL();
            }
            foreach (var el in footer_content.QuerySelectorAll("item.news.b-tabloid__topic_news"))
            {
                cu.header = el.QuerySelector("div.titles h3").TextContent;
                cu.imgUrl = "";
                cu.URL = link + el.QuerySelector("div.titles h3 a").GetAttribute("href");
                cu.description = el.QuerySelector("div.rightcol").TextContent;
                cu.tags = "";
                cu.date = "";
                cu.LoadContentToSQL();
            }
        }
    }
}
