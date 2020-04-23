using LanguageBot.Entities.Video;
using LanguageBot.View;
using System;

namespace LanguageBot._1View.Video
{
    class VideoView : IBaseView
    {
        private VideoMenu video;
        public VideoView(VideoMenu video)
        {
            this.video = video;
        }

        public int GetViewToBackend()
        {
            throw new NotImplementedException();
        }
    }
}
