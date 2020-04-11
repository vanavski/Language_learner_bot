using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Interfaces
{
    interface ILanguage
    {
        int Id { get; set; }



        int Init()
        {
            return 0;
        }
    }
}
