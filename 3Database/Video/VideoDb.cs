using LanguageBot._2Backend.Video;
using LanguageBot.Database;
using System;

namespace LanguageBot._3Database.Video
{
    class VideoDb : IBaseDatabase
    {
        private VideoController controller;

        public VideoDb(VideoController controller)
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
