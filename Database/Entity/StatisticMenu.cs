using LanguageBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Database.Entity
{
    class StatisticMenu: IBaseMenu
    {
        int UserId { get; set; }
        int LanguageId { get; set; }
        int MistakesCount { get; set; }
        DateTime Date { get; set; }
    }
}
