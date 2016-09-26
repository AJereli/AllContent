using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp;
using System.IO;
using AngleSharp.Html;
using AngleSharp.Dom.Collections;
using AngleSharp.Dom.Css;
using AngleSharp.Css;
using AngleSharp.Dom.Xml;
using AngleSharp.Xml;   
using AngleSharp.Parser.Html;
using System.Xml.Linq;

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
                //MessageBox.Show(element.QuerySelector("div.b-articles__b__text p").TextContent);
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
