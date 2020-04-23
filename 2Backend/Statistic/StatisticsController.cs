using LanguageBot._1View.Statistic;
using LanguageBot.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot._2Backend.Statistic
{
    class StatisticsController : IBaseController
    {
        private StatisticsView statistics;

        public StatisticsController(StatisticsView statistics)
        {
            this.statistics = statistics;
        }

        public int GetBackendToDb()
        {
            throw new NotImplementedException();
        }

        public int GetBackendToView()
        {
            throw new NotImplementedException();
        }
    }
}
