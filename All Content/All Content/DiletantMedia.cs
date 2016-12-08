using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;
namespace All_Content
{
    class DiletantMedia : SiteForPars
    {
        List<SiteForPars> all_dt;
        public DiletantMedia() : base("http://diletant.media")
        {
            all_dt = new List<SiteForPars>();
            all_dt.Add(new DiletantNews());
            all_dt.Add(new DiletantArticles());
            
        }
        public override void Pars()
        {
            foreach (var hacker in all_dt)
                hacker.Pars();
        }
    }

    class DiletantNews : SiteForPars
    {
        private string url_link = "http://diletant.media";
        public DiletantNews() : base("http://diletant.media/news/")
        {

        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("ul.publicationslist")
                .QuerySelectorAll("li"))
            {
                cu.URL = url_link + element.QuerySelector("a.pubpreview").GetAttribute("href");
                cu.header = element.QuerySelector("a.pubpreview div.i_title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.i_descr p").TextContent.Trim();
                cu.imgUrl = url_link + element.QuerySelector("a.pubpreview div.img_block img").GetAttribute("src");
                cu.tags = "Дилетант, Новости";
                cu.date = element.QuerySelector("div.i_meta span.datetime span.date").TextContent;
                cu.LoadContentToSQL();
            }
        }
    }

    class DiletantArticles : SiteForPars
    {
        private string url_link = "http://diletant.media";
        public DiletantArticles() : base("http://diletant.media/articles/")
        {

        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("ul.publicationslist")
                .QuerySelectorAll("li"))
            {
                cu.URL = url_link + element.QuerySelector("a.pubpreview").GetAttribute("href");
                cu.header = element.QuerySelector("a.pubpreview div.i_title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.i_descr p").TextContent.Trim();
                cu.imgUrl = url_link + element.QuerySelector("a.pubpreview div.img_block img").GetAttribute("src");
                cu.tags = "Дилетант, История";
                cu.date = element.QuerySelector("div.i_meta span.datetime span.date").TextContent;
                cu.LoadContentToSQL();
            }
        }
    }
}