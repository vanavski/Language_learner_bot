using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Entities
{
    public interface Entity
    {
        Guid Id { get; set; }

        public void Init()
        {
            Id = Guid.NewGuid();
        }
    }
}
