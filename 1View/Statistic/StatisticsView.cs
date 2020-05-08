using LanguageBot.Entities.Statistics;
using LanguageBot.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot._1View.Statistic
{
    public class StatisticsView : IBaseView
    {
        private StatisticsMenu statistics;

        public StatisticsView()
        {

        }
        public StatisticsView(StatisticsMenu statistics)
        {
            this.statistics = statistics;
        }

        public int GetViewToBackend()
        {
            throw new NotImplementedException();
        }
    }
}
