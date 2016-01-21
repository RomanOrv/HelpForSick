using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpForSick.Entities;
using System.Data.Objects;

namespace HelpForSick.Repository
{
    public class EFPersonPageInfoRepository : IPersonPageInfoRepository
    {
        private readonly string _connectionString;
        public EFPersonPageInfoRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public PersonPageInfo GetPersonPageInfo()
        {
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                return context.CreateObjectSet<PersonPageInfo>().FirstOrDefault(x => x.Id == 1);
            }
        }

        public void SetPersonPageInfo(string mainInfo, string diagnosis, string moneyInfo)
        {
            using (ObjectContext context = new ObjectContext(_connectionString))
            {
                PersonPageInfo article = context.CreateObjectSet<PersonPageInfo>().Single(x => x.Id == 1);
                article.MainInfo = mainInfo;
                article.Diagnosis = diagnosis;
                article.MoneyInfo = moneyInfo;
                context.SaveChanges();
            }
        }
    }
}
