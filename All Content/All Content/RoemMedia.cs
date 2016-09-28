using AngleSharp.Dom;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngleSharp;

namespace All_Content 
{

    class RoemMedia : SiteForPars
    {
        public RoemMedia() : base("https://roem.ru/media/")
        {
           

        }

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("body.archive.category.category-media.category-1.group-blog > div.hfeed.site > div.site-wrapper > div.site-content")
               .QuerySelectorAll("div.content-padding-wrapper > div.content-with-sidebar > main.content > section.news-block.news-block-category > ul.news-block-articles-list > li.news-block-article"))
            {
                cu.URL = element.QuerySelector("header.news-block-article-header a").GetAttribute("href");
                //cu.header = element.QuerySelector("header.news-block-article-header a").TextContent;
                cu.URL = element.QuerySelector("header.news-block-article-header a").GetAttribute("href");
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



                cu.source = link;

                cu.tags = "Roem, Media, Роем, Меди";

                try
                {
                    cu.date = element.QuerySelector("aside.news-block-article-thumb-wrapper a").TextContent;
                    cu.description = element.QuerySelector("div.news-block-article-meta a.news-block-article-intro p").TextContent;
                    cu.imgUrl = element.QuerySelector("aside.news-block-article-thumb-wrapper img.news-block-article-thumb.wp-post-image").GetAttribute("src");
                }
                catch (NullReferenceException)
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
