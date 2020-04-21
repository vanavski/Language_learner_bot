using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Backend
{
    public interface IBaseController
    {
        public int GetBackendToView();
        public int GetBackendToDb();
    }
}
