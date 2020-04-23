using System;
using System.Collections.Generic;
using System.Text;
using LanguageBot.Backend;

namespace LanguageBot.Database
{
    public interface IBaseDatabase
    {
        public int GetDbToBackend();
        public int GetToDb();
    }
}
