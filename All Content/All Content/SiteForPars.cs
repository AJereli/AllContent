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

        public string Source;
        protected SiteForPars(string _link)
        {
            link = _link;
            cu = new ContentUnit();
            parser = new HtmlParser();
            config = Configuration.Default.WithDefaultLoader();
            document = BrowsingContext.New(config).OpenAsync(link).Result;
            Source = link;
            cu.source = link;
        }
        protected void LoadDocument()
        {
            document.Dispose();
            document = BrowsingContext.New(config).OpenAsync(link).Result;
        }
        public virtual void Pars() { }
    }
}
