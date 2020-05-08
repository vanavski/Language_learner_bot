using LanguageBot._1View.Cards;
using LanguageBot._1View.Topics;
using LanguageBot.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot
{
    public class CommandInitializer
    {
        private static Dictionary<String, IBaseView> dict = new Dictionary<string, IBaseView>();

        public CommandInitializer()
        {
            dict.Add("/cards", new CardsView());

        }

        public Dictionary<string, IBaseView> GetDictionaty()
        {
            if (dict == null)
            {
                dict = new Dictionary<string, IBaseView>
                {
                    { "/cards", new CardsView() },
                    { "/topic", new TopicsView() },
                    { "/game", new CardsView() }
                };
            }
            return dict;
        }
    }
}
