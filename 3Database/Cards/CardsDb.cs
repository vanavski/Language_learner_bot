using LanguageBot._2Backend.Cards;
using LanguageBot.Database;
using System;

namespace LanguageBot._3Database.Cards
{
    class CardsDb : IBaseDatabase
    {
        private CardsController cards;

        public CardsDb(CardsController cards)
        {
            this.cards = cards;
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
