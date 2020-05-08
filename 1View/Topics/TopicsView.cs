using LanguageBot.Entities.Topics;
using LanguageBot.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot._1View.Topics
{
    public class TopicsView : IBaseView
    {
        private TopicsMenu topics;

        public TopicsView()
        {

        }
        public TopicsView(TopicsMenu topics)
        {
            this.topics = topics;
        }

        public int GetViewToBackend()
        {
            throw new NotImplementedException();
        }
    }
}
