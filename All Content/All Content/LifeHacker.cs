using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;


namespace All_Content
{
    class LifeHacker : SiteForPars
    {
        List<SiteForPars> all_lf;
        public LifeHacker() : base ("https://lifehacker.ru")
        {
            all_lf = new List<SiteForPars>();
            all_lf.Add(new LifehackerWork());
            all_lf.Add(new LifehackerTechnology());
            all_lf.Add(new LifehackerSport());
            all_lf.Add(new LifehackerRewiew());
            all_lf.Add(new LifehackerRelax());
            all_lf.Add(new LifehackerLife());
            all_lf.Add(new LifehackerInfogrophics());
            all_lf.Add(new LifehackerHealth());
            all_lf.Add(new LifehackerAllTop());
        }
        public override void Pars()
        {
            foreach (var hacker in all_lf)
                hacker.Pars();
        }
    }

    class LifehackerAllTop : SiteForPars
    {
        public LifehackerAllTop() : base("https://lifehacker.ru/top/all/")
        {
            
        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Лучшее, Лайфхакер-ТОП";
                cu.LoadContentToSQL();
            }
        }
    }

    class LifehackerHealth : SiteForPars
    {
        public LifehackerHealth() : base("https://lifehacker.ru/topics/health/")
        {
            
        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Здоровье";
                cu.LoadContentToSQL();
            }
        }
    }

    class LifehackerInfogrophics : SiteForPars
    {
        public LifehackerInfogrophics() : base("https://lifehacker.ru/topics/infographics/")
        {
            
        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Инфографики";
                cu.LoadContentToSQL();
            }
        }
    }

    class LifehackerLife : SiteForPars
    {
        public LifehackerLife() : base("https://lifehacker.ru/topics/life/")
        {
            
        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Жизнь";
                cu.LoadContentToSQL();
            }
        }
    }

    class LifehackerRelax : SiteForPars
    {
        public LifehackerRelax() : base("https://lifehacker.ru/topics/relax/")
        {

        }

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Отдых";
                cu.LoadContentToSQL();
            }
        }
    }

    class LifehackerRewiew : SiteForPars
    {
        public LifehackerRewiew() : base("https://lifehacker.ru/tag/obzor/")
        {
            
        }

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Обзор, Технологии, Новинки";
                cu.LoadContentToSQL();
            }
        }
    }

    class LifehackerSport : SiteForPars
    {
        public LifehackerSport() : base("https://lifehacker.ru/stream/runner/")
        {
            
        }

        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = @element.QuerySelector("div.col-sm-16 a").@GetAttribute("href");
                cu.header = @element.QuerySelector("div.col-sm-16 a h2.flow-post__title").@TextContent;
                cu.source = link;
                cu.description = @element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").@TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Спорт";
                cu.LoadContentToSQL();
            }
        }

    }

    class LifehackerTechnology : SiteForPars
    {
        public LifehackerTechnology() : base("https://lifehacker.ru/topics/technology/")
        {
           
        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
               .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Технологии";
                cu.LoadContentToSQL();
            }
        }
    }

    class LifehackerWork : SiteForPars
    {
        public LifehackerWork() : base("https://lifehacker.ru/topics/work/")
        {
            
        }
        public override void Pars()
        {
            IDocument document = BrowsingContext.New(config).OpenAsync(link).Result;
            foreach (IElement element in document.QuerySelector("div.flow.container-fluid div.row div.col-md-18.flow__posts")
                .QuerySelectorAll("div.flow-post"))
            {
                cu.URL = element.QuerySelector("div.col-sm-16 a").GetAttribute("href");
                cu.header = element.QuerySelector("div.col-sm-16 a h2.flow-post__title").TextContent;
                cu.source = link;
                cu.description = element.QuerySelector("div.col-sm-16 p.flow-post__excerpt").TextContent;
                cu.imgUrl = element.QuerySelector("img.flow-post__image").GetAttribute("src");
                cu.tags = "Лайфхакер, Работа";
                cu.LoadContentToSQL();
            }
        }
    }


}
