
using AutoMapper;
using CrossPay.ElasticSearch;
using CrossPay.ElasticSearch.Data;
using CrossPay.ElasticSearch.Repositories;
using CrossPay.ElasticSearch.Repositories.Interfaces;
using CrossPay.ElasticSearch.Repositories.Repositories;
using CrossPay.ElasticSearch.Services;
using CrossPay.ElasticSearch.Services.Configs.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CrossBorderContext"].ConnectionString;
        var mongo = System.Configuration.ConfigurationManager.ConnectionStrings["WatchDogConnectionString"].ConnectionString;

        var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {

            var configMap = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfile()); });
            var mapper = configMap.CreateMapper();
            services.AddSingleton(mapper);


            // Get the connection string from the configuration
            services.AddDbContext<CrossBordaDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableDetailedErrors(); // This enables detailed error messages
            });

            services.AddAppServices(hostContext.Configuration, mongo);
            services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddHostedService<ElastricSearchUpdaterService>();
        })
        .Build();


        // Get the connection string from the configuration

        await host.RunAsync();
    }


}