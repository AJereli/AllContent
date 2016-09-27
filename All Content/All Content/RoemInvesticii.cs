using AngleSharp.Dom;
using System.Windows;
using System;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
namespace All_Content
{
    class RoemInvesticii : SiteForPars
    {
    public RoemInvesticii() : base ("https://roem.ru/investments/")
        {
            foreach(IElement element in document.QuerySelector("body.archive.category.category-investments.category-4.group-blog  > div.hfeed.site > div.site-wrapper > div.site-content")
                .QuerySelectorAll("div.content-padding-wrapper > div.content-with-sidebar > main.content > section.news-block.news-block-category > ul.news-block-articles-list > li.news-block-article"))
            {
                cu.URL = element.QuerySelector("header.news-block-article-header a").GetAttribute("href");
                cu.source = link;
                cu.tags = "Roem , Investicii, Инвестиции, Роем";
                string tmpheader1 = element.QuerySelector("header.news-block-article-header a").TextContent;
                string tmpheader2 = element.QuerySelector("header.news-block-article-header").LastElementChild.TextContent;

                if (String.Compare(tmpheader1, tmpheader2) > 0)
                { 
                    cu.header = element.QuerySelector("header.news-block-article-header a").TextContent;

                }
                else
                {
                    cu.header = element.QuerySelector("header.news-block-article-header").LastElementChild.TextContent;
                }
                try
                {
                    cu.date = element.QuerySelector("aside.news-block-article-thumb-wrapper a").TextContent;
                    cu.description = element.QuerySelector("div.news-block-article-meta a.news-block-article-intro p").TextContent;
                    cu.imgUrl = element.QuerySelector("aside.news-block-article-thumb-wrapper  img.news-block-article-thumb.wp-post-image").GetAttribute("src");
                }
                
                catch(NullReferenceException)
                {
                    cu.date = element.QuerySelector("header.news-block-article-header a").TextContent;
                    cu.description = "";
                    cu.imgUrl = "";
                }         
                cu.LoadContentToSQL();
            }

        }

    }
}
