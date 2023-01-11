using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyChecker.Data;

namespace VocabularyChecker
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(@"Data Source=.\\SQLEXPRESS;Initial Catalog=Vocabulary;Integrated Security=True"));
        }
    }
}
