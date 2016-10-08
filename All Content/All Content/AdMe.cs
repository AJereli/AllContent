using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;


namespace All_Content
{
    class AdMe : SiteForPars
    {
        List<SiteForPars> all_am;
        public AdMe() : base("https://www.adme.ru")
        {
            all_am = new List<SiteForPars>();
            all_am.Add(new AdMeArtists());
            all_am.Add(new AdMePhotographers());
            all_am.Add(new AdMeWriters());
            all_am.Add(new AdMeDesign());
            all_am.Add(new AdMeAdvertising());
            all_am.Add(new AdMeMusic());
            all_am.Add(new AdMeCinema());
            all_am.Add(new AdMeTravels());
            all_am.Add(new AdMePsychology());
            all_am.Add(new AdMeCulture());
            all_am.Add(new AdMeAuthorСolumn());
            all_am.Add(new AdMeAmateurPerformances());
            all_am.Add(new AdMeFolkArt());
            all_am.Add(new AdMeFamily());
            all_am.Add(new AdMeGood());
            all_am.Add(new AdMeAnimals());
            all_am.Add(new AdMeNostalgia());
            all_am.Add(new AdMeMarasmus());
            all_am.Add(new AdMeScience());
            all_am.Add(new AdMeKitchen());
        }
        public override void Pars()
        {
            foreach (var adme in all_am)
                adme.Pars();
        }
    }

    class AdMeArtists : SiteForPars
    {
        public AdMeArtists() : base("https://www.adme.ru/tvorchestvo-hudozhniki/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Художники";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMePhotographers : SiteForPars
    {
        public AdMePhotographers() : base("https://www.adme.ru/tvorchestvo-fotografy/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Фотографы";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeWriters : SiteForPars
    {
        public AdMeWriters() : base("https://www.adme.ru/tvorchestvo-pisateli/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Писатели";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeDesign : SiteForPars
    {
        public AdMeDesign() : base("https://www.adme.ru/tvorchestvo-dizajn/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Дизайн";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeAdvertising : SiteForPars
    {
        public AdMeAdvertising() : base("https://www.adme.ru/tvorchestvo-reklama/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Реклама";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeMusic : SiteForPars
    {
        public AdMeMusic() : base("https://www.adme.ru/tvorchestvo-muzyka/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Музыка";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeCinema : SiteForPars
    {
        public AdMeCinema() : base("https://www.adme.ru/tvorchestvo-kino/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Кино";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeTravels : SiteForPars
    {
        public AdMeTravels() : base("https://www.adme.ru/svoboda-puteshestviya/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Путишествия";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMePsychology : SiteForPars
    {
        public AdMePsychology() : base("https://www.adme.ru/svoboda-psihologiya/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Психология";
                cu.LoadContentToSQL();
            }
        }
    }
    class AdMeCulture : SiteForPars
    {
        public AdMeCulture() : base("https://www.adme.ru/svoboda-kultura/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Культура";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeAuthorСolumn : SiteForPars
    {
        public AdMeAuthorСolumn() : base("https://www.adme.ru/svoboda-avtorskie-kolonki/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeAmateurPerformances : SiteForPars
    {
        public AdMeAmateurPerformances() : base("https://www.adme.ru/svoboda-sdelaj-sam/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeFolkArt : SiteForPars
    {
        public AdMeFolkArt() : base("https://www.adme.ru/svoboda-narodnoe-tvorchestvo/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }
    class AdMeFamily : SiteForPars
    {
        public AdMeFamily() : base("https://www.adme.ru/zhizn-semya/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe, Семья";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeGood : SiteForPars
    {
        public AdMeGood() : base("https://www.adme.ru/zhizn-dobro/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeAnimals : SiteForPars
    {
        public AdMeAnimals() : base("https://www.adme.ru/zhizn-zhivotnye/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeNostalgia : SiteForPars
    {
        public AdMeNostalgia() : base("https://www.adme.ru/zhizn-nostalgiya/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeMarasmus : SiteForPars
    {
        public AdMeMarasmus() : base("https://www.adme.ru/zhizn-marazmy/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeScience : SiteForPars
    {
        public AdMeScience() : base("https://www.adme.ru/zhizn-nauka/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }

    class AdMeKitchen : SiteForPars
    {
        public AdMeKitchen() : base("https://www.adme.ru/zhizn-kuhnya/")
        {

        }
        private string url_link = "https://www.adme.ru";

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("section.content ul.article-list")
                .QuerySelectorAll("li.article-list-block.js-article-list-item"))
            {

                cu.URL = url_link + element.QuerySelector("a").GetAttribute("href");
                cu.header = element.QuerySelector("h3.al-title a").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("p.al-descr").TextContent;
                cu.imgUrl = element.QuerySelector("a img.al-pic").GetAttribute("src");
                cu.tags = "AdMe";
                cu.LoadContentToSQL();
            }
        }
    }
}
