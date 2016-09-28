using AngleSharp;
using AngleSharp.Dom;
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


        }

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            var main_new = document.QuerySelector("div.row div.span8 div.first-item");
            cu.header = main_new.QuerySelector("h2").TextContent;
            try
            {
                cu.imgUrl = main_new.QuerySelector("a img.g-picture").GetAttribute("src");
            }catch (NullReferenceException)
            {
                cu.imgUrl = "";
            }
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
            var footer_content = document.QuerySelector("section.b-layout.js-layout.b-layout_main div.row div.span8 div.row.js-content");
            //  MessageBox.Show(footer_content.OuterHtml);
            foreach (var el in document.QuerySelectorAll("section.b-longgrid-column div.item.article"))
            {
                cu.header = el.QuerySelector("div.titles h3").TextContent;
                cu.imgUrl = el.QuerySelector("img.g-picture").GetAttribute("src");
                cu.URL = link + el.QuerySelector("a.js-dh.picture").GetAttribute("href");
                cu.description = el.QuerySelector("div.rightcol").TextContent;
                try
                {
                    cu.tags = el.QuerySelector("div.info.g-date.item__info a").TextContent;
                }
                catch (NullReferenceException)
                {
                    cu.tags = "";
                }
                cu.date = "";
                cu.LoadContentToSQL();
            }
            foreach (var el in document.QuerySelectorAll("item.news.b-tabloid__topic_news"))
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
