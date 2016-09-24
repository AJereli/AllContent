using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Parser.Html;
using AngleSharp.Dom;

namespace All_Content
{
    class Lifehacker
    {
        HtmlParser parser = new HtmlParser();
        static string link = "https://tjournal.ru";

        static IConfiguration config = Configuration.Default.WithDefaultLoader();

        public Lifehacker()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                    .QuerySelectorAll("div.flow-post"))
            {
                .QuerySelector("div.col-sm-16 a h2.flow-post__title")
                .QuerySelector("div.col-sm-16 p.flow-post__excerpt")
                .QuerySelector("div.col-sm-16 a").GetAttribute("href")               
            }
        }
    }
}
