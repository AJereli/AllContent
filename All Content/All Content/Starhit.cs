using AngleSharp;
using AngleSharp.Dom;
//Starhit-новости
namespace All_Content
{
    class Starhit : SiteForPars
    {
        public Starhit() : base("http://www.starhit.ru/novosti/")
        {

        }
        private string url_link = "http://www.starhit.ru";
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;

            foreach (IElement element in document.QuerySelector("div.news-lister ul.news-list-container")
                 .QuerySelectorAll("li.item"))
            {
                cu.URL = url_link + element.QuerySelector("a.item-link").GetAttribute("href");
                cu.header = element.QuerySelector("a.item-link span.item-title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.item-text").TextContent;
                cu.imgUrl = element.QuerySelector("a.item-link img").GetAttribute("src");
                cu.tags = "Starhit, Шоу-бизнес";
                cu.date = element.QuerySelector("span.item-date").TextContent;
                cu.LoadContentToSQL();
            }
        }
    }
}