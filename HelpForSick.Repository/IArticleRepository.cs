using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpForSick.Entities;
namespace HelpForSick.Repository
{
    public interface IArticleRepository
    {
        Article GetArticle();
        void SetArticleContent(string content);
    }
}
