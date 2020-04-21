using LanguageBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Entities.Video
{
    class VideoMenu: IBaseMenu
    {
        List<Tuple<string, string>> Links { get; set; }
    }
}
