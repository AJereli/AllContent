using System;
using AngleSharp;
using AngleSharp.Dom;
//librebook - новости
namespace All_Content
{
    class LibrebookNews : SiteForPars
    {
        public LibrebookNews() : base("http://librebook.ru/news/allnews")
        {

        }
        private string url_link = "http://librebook.ru";
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;

            foreach (IElement element in document.QuerySelector("div.leftContent")
                 .QuerySelectorAll("div.panel.news.panel-default"))
            {
                cu.URL = url_link + element.QuerySelector("div.panel-heading h4.panel-title a").GetAttribute("href");
                cu.header = element.QuerySelector("div.panel-heading h4.panel-title a").TextContent.Trim();
                cu.source = link;
                cu.description = element.QuerySelector("div.panel-body div.summary").TextContent;
                try
                {
                    cu.imgUrl = element.QuerySelector("div.panel-body div.summary div img").GetAttribute("src");
                }
                catch (NullReferenceException)
                {
                    cu.imgUrl = "";
                }
                cu.tags = "Книги, Литература";
                cu.date = element.QuerySelector("div.panel-footer.clearfix span").TextContent;
                cu.LoadContentToSQL();
            }
        }
    }
}