using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using System.Windows;


namespace All_Content
{
    class NplusOne_Space
    {
        HtmlParser parser;
        string link = "https://nplus1.ru/rubric/space";
        IConfiguration config;
        IDocument document;
        ContentUnit cu;
        public NplusOne_Space()
        {
            cu = new ContentUnit();
            parser = new HtmlParser();
            config = Configuration.Default.WithDefaultLoader();
            document = BrowsingContext.New(config).OpenAsync(link).Result;
            var a = document.All.Where(m => m.Id == "main").First();
            MessageBox.Show(a.OuterHtml);
            //foreach (IElement element in document.Body.QuerySelectorAll(
            //    )
            //{
            //    cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
            //    cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
            //    cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
            //    cu.imgUrl = "";
            //    cu.source = link;
            //    cu.tags = "since;space;";
            //}
        }


    }
}
