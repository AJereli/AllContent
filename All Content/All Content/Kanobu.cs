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
    class Kanobu : SiteForPars
    {
       

        public Kanobu() : base ("http://kanobu.ru/")
        {

            var all_news = document.All.Where(m => m.Id == "mainpage-news").First().QuerySelectorAll("div.caption");

        }
    }
}
