using AngleSharp.Dom;
//Лайфхакер - Обзоры
namespace All_Content
{
    class LifehackerRewiew : SiteForPars
    {
        public LifehackerRewiew() : base("https://lifehacker.ru/tag/obzor/")
        {
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
}