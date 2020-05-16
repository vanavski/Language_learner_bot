using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LanguageBot.Entity
{
    public class Result
    {
        [Key]
        public int Id { get; private set; }

        public long? UserId { get; set; }

        public int RightAnsw { get; set; }

        public int WrongAnsw { get; set; }

        public DateTime Date { get; set; }
    }
}
