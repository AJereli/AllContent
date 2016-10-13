using System;
using AngleSharp;
using AngleSharp.Dom;
//РИА-лента
namespace All_Content
{
    class RiaNews : SiteForPars
    {
        public RiaNews() : base("https://ria.ru/lenta")
        {

        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;

            foreach (IElement element in document.QuerySelector("div.b-list")
                 .QuerySelectorAll("div.b-list__item"))
            {
                cu.URL = link + element.QuerySelector("div.b-list__item a").GetAttribute("href");
                cu.header = element.QuerySelector("div.b-list__item span.b-list__item-title").TextContent;
                cu.source = link;
                try
                {
                    cu.description = element.QuerySelector("div.b-list__item-announce span").TextContent;
                }
                catch (NullReferenceException)
                {
                    cu.description = "";
                }
                cu.imgUrl = element.QuerySelector("a span.b-list__item-img span.b-list__item-img-ind img").GetAttribute("src");
                cu.tags = "РИА-Новости, Новости";
                cu.date = element.QuerySelector("div.b-list__item-date span").TextContent;
                cu.LoadContentToSQL();
            }
        }
    }
}