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
    class Kanobu : SiteForPars
    {


        public Kanobu() : base("http://kanobu.ru/news")
        {

            var all_news = document.Body.QuerySelectorAll("ul.news-list.mtl.clearfix");
            foreach (var big_block in all_news)
            {
                
                foreach (var el in big_block.QuerySelectorAll("li.news-list-item"))
                {
                    try
                    {
                        cu.imgUrl = el.QuerySelector("div.news-block div.news--img-n-category img").GetAttribute("src");
                    }
                    catch (NullReferenceException)
                    {
                        continue;
                    }


                    cu.URL = link + el.QuerySelector("div.news-block a").GetAttribute("href");
                    cu.header = el.QuerySelector("span.h2.news-info--header").TextContent;
                    cu.tags = el.QuerySelector("span.news-info-category-main").TextContent;
                    cu.date = el.GetAttribute("data-longread-pubdate");
                    cu.LoadContentToSQL();
                }

                foreach (var el in big_block.QuerySelectorAll("li.news-more-item a"))
                {
                    cu.URL = link + el.GetAttribute("href");
                    cu.imgUrl = el.FirstElementChild.GetAttribute("src");
                    cu.header = el.LastElementChild.QuerySelector("span.mrs").TextContent;
                    try {
                        cu.tags = el.LastElementChild.QuerySelector("span.news-item-small-category").TextContent.Remove(0,2);
                    }catch (NullReferenceException)
                    {
                        cu.tags = "";
                    }
                    cu.LoadContentToSQL();
                }
            }
        }
    }
}
