using CrossPay.ElasticSearch.Entities;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using WatchDog;
using WatchDog.src.Enums;
using Microsoft.Extensions.Configuration;
using Nest;
using CrossPay.ElasticSearch.Services;
using CrossPay.ElasticSearch.Entities.Indexes;
using AutoMapper;
using CrossPay.ElasticSearch.Services.Configs.Mappers;
using CrossPay.ElasticSearch.Utilities;
using CrossPay.ElasticSearch.Repositories.Interfaces;

namespace CrossPay.ElasticSearch
{
    public static class ServiceExtension
    {
        public static void AddAppServices(this IServiceCollection services,
           IConfiguration configuration, string mongodb)
        {
            var elasticsearchUrl = System.Configuration.ConfigurationManager.AppSettings["ElasticSearchUrl"];
            var elasticsearchpassword = System.Configuration.ConfigurationManager.AppSettings["ElasticSearchPassword"];

            var connectionSettings = new Nest.ConnectionSettings(new Uri(elasticsearchUrl))
                                       .EnableDebugMode()
                                       .PrettyJson(false)
                                       .BasicAuthentication("elastic", elasticsearchpassword)
                                       .DefaultIndex(Constants.Index)
                                       .DefaultMappingFor<SuccessfulTransactionIndex>(i => i.IndexName(Constants.SuccessfulTransactionIndex))
                                       .DefaultMappingFor<InActiveUserProfileIndex>(i => i.IndexName(Constants.InActiveUserProfileIndex))
                                       .DefaultMappingFor<ActiveUserProfileIndex>(i => i.IndexName(Constants.ActiveUserProfileIndex))
                                       .DefaultMappingFor<UserProfile>(i => i.IndexName(Constants.UserProfile))
                                       .DefaultMappingFor<FailedTransactionIndex>(i => i.IndexName(Constants.FailedTransactionIndex))
                                       .DisableDirectStreaming();

            var client = new ElasticClient(connectionSettings);

            services.AddTransient<ElastricSearchUpdaterService>();
            services.AddTransient<ILoggerService, LoggerService>();

            services.AddSingleton(client);

            //services.AddWatchDogServices(opt =>
            //{
            //    opt.IsAutoClear = true;
            //    opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Weekly;
            //    opt.DbDriverOption = WatchDogDbDriverEnum.Mongo;
            //    opt.SetExternalDbConnString = mongodb;
            //});

            
        }
    }
}
