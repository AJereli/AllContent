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

        static IConfiguration config = Configuration.Default.WithDefaultLoader();
        public TJpars()
        {
                    

            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach(IElement element in  document.QuerySelector("div.l-container > div.b-container")
                .QuerySelector("main.b-content >  div.b-w-feed > div.hereIsLoadMoreContainer")
                .QuerySelector("div.b-block > div.b-articles loadMoreHere")
                .QuerySelectorAll("b-articles__b b-articles__b_t2 b-articles__b_t2_1 b-articles__b_t2_1_1 jk-navigation"))
            {
             
            }
        
        }
       
    }
}
