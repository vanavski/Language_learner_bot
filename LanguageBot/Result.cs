using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Entity
{
    public class Result
    {
        public int Id { get; set; }

        public long? UserId { get; set; }

        public DateTime Date { get; set; }

        public int RightAnsw { get; set; }

        public int WrongAnsw { get; set; }
    }
}
