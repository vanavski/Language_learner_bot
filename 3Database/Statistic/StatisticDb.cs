using LanguageBot._2Backend.Statistic;
using LanguageBot.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot._3Database.Statistic
{
    class StatisticDb : IBaseDatabase
    {
        private StatisticsController statistics;

        public StatisticDb(StatisticsController statistics)
        {
            this.statistics = statistics;
        }

        public int GetDbToBackend()
        {
            throw new NotImplementedException();
        }

        public int GetToDb()
        {
            throw new NotImplementedException();
        }
    }
}
