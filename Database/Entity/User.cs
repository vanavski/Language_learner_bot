using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Database.Entity
{
    class User
    {
        int Id;
        int LanguageId;
        bool FromNativeLanguage; //вынести как обработку команды
        GameType gameType;
        WordsType wordsType;
        string k = "текущая команда";
    }
}
