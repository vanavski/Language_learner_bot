using LanguageBot.Entities.Cards;
using LanguageBot.View;
using System;

namespace LanguageBot._1View.Cards
{
    class CardsView : IBaseView
    {
        private CardsMenu cards;

        public CardsView(CardsMenu cards)
        {
            this.cards = cards;
        }

        public int GetViewToBackend()
        {
            throw new NotImplementedException();
        }
    }
}
