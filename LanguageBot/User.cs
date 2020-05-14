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
<<<<<<< Updated upstream:LanguageBot/User.cs
=======

        public int RightAnsw { get; set; }

        public int WrongAnsw { get; set; }

        public int QuestCounter { get; set; }
>>>>>>> Stashed changes:LanguageBot/Entity/User.cs
    }
}
