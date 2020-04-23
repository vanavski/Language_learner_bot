using LanguageBot._1View.Video;
using LanguageBot.Backend;
using System;

namespace LanguageBot._2Backend.Video
{
    class VideoController : IBaseController
    {
        private VideoView view;
        public VideoController(VideoView view)
        {
            this.view = view;
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
