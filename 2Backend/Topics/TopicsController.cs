using LanguageBot._1View.Topics;
using LanguageBot.Backend;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot._2Backend.Topics
{
    class TopicsController : IBaseController
    {
        private TopicsView topics;

        public TopicsController(TopicsView topics)
        {
            this.topics = topics;
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
