using AngleSharp.Dom;
using AngleSharp;
using AngleSharp.Parser.Html;

namespace All_Content
{
    class TJpars : SiteForPars
    {


        public TJpars() : base("https://tjournal.ru")
        {

        }
        public override void Pars()
        {
            IDocument document;
            
                 document = BrowsingContext.New(config).OpenAsync(link).Result;

            
            foreach (IElement element in document.Body.QuerySelector("div.l-container > div.b-container")
                .QuerySelectorAll("main.b-content > div.b-w-feed > div.hereIsLoadMoreContainer > div.b-block > div.b-articles.loadMoreHere > div.b-articles__b.b-articles__b_t2.b-articles__b_t2_1.b-articles__b_t2_1_1.jk-navigation")

                )
            {
                cu.header = element.QuerySelector("div.b-articles__b__title").TextContent;
                cu.description = element.QuerySelector("div.b-articles__b__text p").TextContent;
                cu.imgUrl = element.QuerySelector("div.b-articles__b__image img").GetAttribute("src");
                cu.URL = element.QuerySelector("div.b-articles__b__content div.b-articles__b__image a").GetAttribute("href");
                cu.tags = "TJ";
                cu.source = link;
                cu.LoadContentToSQL();
            }
        }

    }
}
