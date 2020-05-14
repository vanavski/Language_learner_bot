using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot
{
    public class User
    {
        public long? Id { get; set; }

        public string PreviousCommand { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }
    }
}
