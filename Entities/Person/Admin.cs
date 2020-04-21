using LanguageBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Entities.Person
{
    class Admin : IPerson
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
