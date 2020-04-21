using LanguageBot.Interfaces;
using LanguageBot.Interfaces.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Entities.Person
{
    class User : IPerson
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        ILanguage Language;
        bool FromNativeLanguage; //вынести как обработку команды
        GameType gameType;
        WordType wordsType;
        string k = "текущая команда";
    }
}
