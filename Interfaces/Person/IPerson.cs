using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Interfaces
{
    interface IPerson
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
