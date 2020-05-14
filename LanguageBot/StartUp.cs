using LanguageBot.DataBase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LanguageBot.DataBase.Repositories;

namespace LanguageBot
{
    public static class StartUp
    {
        public static void Start() 
        {
            var service = Depends.Service;
            var cnsstr = DBUtils.ConnectionStr;
            service.AddDbContext<DBPGSQLUtils>(op => op.UseNpgsql(cnsstr));
<<<<<<< Updated upstream
            service.AddTransient<Repository>();
=======
            //TODO: add different reps
            service.AddTransient<UsersRepository>();
            service.AddTransient<QuestionRepository>();
            service.AddTransient<StatisticsRepository>();
>>>>>>> Stashed changes
            Depends.Provider = Depends.Service.BuildServiceProvider();
            //////////////
        }

        
    }
}
