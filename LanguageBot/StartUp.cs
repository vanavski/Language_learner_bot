using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LanguageBot
{
    public static class StartUp
    {
        public static void Start() 
        {
            var service = Depends.Service;
            var cnsstr = DBUtils.ConnectionStr;
            service.AddDbContext<DBPGSQLUtils>(op => op.UseNpgsql(cnsstr));
            service.AddTransient<Repository>();
            Depends.Provider = Depends.Service.BuildServiceProvider();
            //////////////
        }

        
    }
}
