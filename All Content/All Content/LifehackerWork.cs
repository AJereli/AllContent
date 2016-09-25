using AngleSharp.Dom;
//Лайфхакер - Работа
namespace All_Content
{
    class LifehackerWork : SiteForPars
    {
        public LifehackerWork() : base("https://lifehacker.ru/topics/work/")
        {
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