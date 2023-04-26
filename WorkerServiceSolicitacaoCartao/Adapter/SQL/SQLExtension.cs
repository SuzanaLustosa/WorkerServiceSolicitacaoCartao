//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WorkerServiceSolicitacaoCartao.Adapter.SQL
//{
//    public static class SQLExtension
//    {
//        public static IServiceCollection AddSQLExtension(this IServiceCollection services)
//        {
//            IConfiguration configuration = new ConfigurationBuilder()
//              .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json")
//              .Build();
//            services.AddSingleton(x => configuration.GetSection("SQLDBConnection").Get<ConnectionStrings>());
//        }
//    }
//}
