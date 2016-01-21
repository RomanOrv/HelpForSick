using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpForSick.Entities;
using System.Data.Objects;

namespace HelpForSick.Repository
{
    public class EFArticleRepository : IArticleRepository
    {

        private readonly string _connectionString;
        public EFArticleRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void CreateArticle(string title)
        {
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                var articles = context.CreateObjectSet<Article>();
                int maxId = articles.Any() ? articles.Max(x => x.Id) : 1;

                Article newArticle = new Article()
                {
                    Id = +maxId,
                    Title = title,
                    Content = string.Empty,
                    CreationTime = DateTime.Now,
                    Published = true
                };

                articles.AddObject(newArticle);
                context.SaveChanges();
            };
        }

        public Article GetArticle()
        {
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                return context.CreateObjectSet<Article>().FirstOrDefault(x => x.Id == 1);
            }
        }

        public void SetArticleContent(string content)
        {
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                Article article = context.CreateObjectSet<Article>().Single(x => x.Id == 1);
                article.Content = content;
                context.SaveChanges();
            }
        }
    }
}
