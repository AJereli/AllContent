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
    interface IPageParsed
    {
        HtmlParser parser { get; set; }
        string link { get; set; }
        IConfiguration config { get; set; }
        IDocument document { get; set; }
        ContentUnit cu { get; set; }
    }
}
