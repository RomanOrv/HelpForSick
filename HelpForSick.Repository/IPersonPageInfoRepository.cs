using HelpForSick.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpForSick.Repository
{
    public interface IPersonPageInfoRepository
    {
        PersonPageInfo GetPersonPageInfo();
        void SetPersonPageInfo(string mainInfo, string diagnosis, string moneyInfo);
    }
}
