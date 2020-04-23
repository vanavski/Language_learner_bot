using LanguageBot._2Backend.Topics;
using LanguageBot.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot._3Database.Topics
{
    class TopicsDb : IBaseDatabase
    {
        private TopicsController controller;

        public TopicsDb(TopicsController controller)
        {
            this.controller = controller;
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
