using LanguageBot._1View.Cards;
using LanguageBot.Backend;
using System;

namespace LanguageBot._2Backend.Cards
{
    class CardsController : IBaseController
    {
        private CardsView cards;

        public CardsController(CardsView cards)
        {
            this.cards = cards;
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
