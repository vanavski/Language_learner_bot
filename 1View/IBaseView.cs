using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.View
{
    public interface IBaseView
    {
        public void GetViewToBackend(string query);
        public bool CheckCommand();
    }
}
