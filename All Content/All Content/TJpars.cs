using AngleSharp.Dom;
using AngleSharp;   
using AngleSharp.Parser.Html;

namespace All_Content
{
    class TJpars
    {

        HtmlParser parser = new HtmlParser();
        static string link = "https://tjournal.ru";
        ContentUnit cont;
        static IConfiguration config = Configuration.Default.WithDefaultLoader();
        public TJpars()
        {

            cont = new ContentUnit();
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.Body.QuerySelector("div.l-container > div.b-container")
                .QuerySelectorAll("main.b-content > div.b-w-feed > div.hereIsLoadMoreContainer > div.b-block > div.b-articles.loadMoreHere > div.b-articles__b.b-articles__b_t2.b-articles__b_t2_1.b-articles__b_t2_1_1.jk-navigation")

                )
            {
                cont.header = element.QuerySelector("div.b-articles__b__title").TextContent;
                cont.description = element.QuerySelector("div.b-articles__b__text p").TextContent;
                cont.imgUrl = element.QuerySelector("div.b-articles__b__image img").GetAttribute("src");
                cont.URL = element.QuerySelector("div.b-articles__b__content div.b-articles__b__image a").GetAttribute("href");
                cont.tags = "TJ";
                cont.source = link;
                cont.LoadContentToSQL();
            }

        }

    }
}
