using AngleSharp;
using AngleSharp.Dom;

namespace All_Content
{
    class KinoPoisk : SiteForPars
    {
        public KinoPoisk() : base("https://www.kinopoisk.ru/news")
        {

        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelectorAll("div.newsList div.item"))
            {
                cu.header = element.QuerySelector("div.title a").TextContent;
                cu.description = element.QuerySelector("div.descr").TextContent;
                cu.imgUrl = element.QuerySelector("div.pic a img").GetAttribute("src");
                cu.URL = link + element.QuerySelector("div.title a").GetAttribute("href");
                cu.tags = "Kinopoisk;Kino;";
                cu.source = link;
                cu.date = element.QuerySelector("div.date").TextContent;
                cu.LoadContentToSQL();

            }
            document = BrowsingContext.New(config).OpenAsync("https://www.kinopoisk.ru/news/perpage/25/page/2/").Result;
            foreach (IElement element in document.QuerySelectorAll("div.newsList div.item"))
            {
                cu.header = element.QuerySelector("div.title a").TextContent;
                cu.description = element.QuerySelector("div.descr").TextContent;
                cu.imgUrl = element.QuerySelector("div.pic a img").GetAttribute("src");
                cu.URL = link + element.QuerySelector("div.title a").GetAttribute("href");
                cu.tags = "Kinopoisk;Kino;";
                cu.source = link;
                cu.date = element.QuerySelector("div.date").TextContent;
                cu.LoadContentToSQL();

            }
        }

    }
}
