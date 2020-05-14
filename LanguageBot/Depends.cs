using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot
{
    public static class Depends
    {
        public static ServiceCollection Service { get; set; } = new ServiceCollection();

        public static IServiceProvider Provider { get; set; }

        public static IConfiguration Configuration { get; set; }
    }
}
