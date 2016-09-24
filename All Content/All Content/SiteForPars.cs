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
    abstract class SiteForPars
    {
        protected HtmlParser parser { get; set; }
        protected string link { get; set; }
        protected IConfiguration config { get; set; }
        protected IDocument document { get; set; }
        protected ContentUnit cu { get; set; }

    }
}
