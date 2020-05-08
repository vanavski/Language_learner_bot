using LanguageBot.Entities.Cards;
using LanguageBot.View;
using System;
using System.Collections.Generic;

namespace LanguageBot._1View.Cards
{
    public class CardsView : IBaseView
    {
        private static string lastCommand = "";
        private CardsMenu cards;
        private List<string> availableCommands;


        public CardsView(/*CardsMenu cards*/)
        {
            availableCommands = new List<string>();
            availableCommands.Add("/game");
            //this.cards = cards;
        }

        public void GetViewToBackend(string query)
        {
            throw new NotImplementedException();
        }

        public bool CheckCommand()
        {
            // обращение к бд (проверка последней команды пользователя)
            return availableCommands.Contains(lastCommand);
        }
    }
}
