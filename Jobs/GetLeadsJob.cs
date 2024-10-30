﻿using LMSWebService.Models;
using Newtonsoft.Json;
using NLog;
using Quartz;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LMSWebService.Jobs
{
    [DisallowConcurrentExecution]
    public class GetLeadsJob : IJob
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IServiceScopeFactory serviceScopeFactory;

        private readonly IConfiguration _configuration;

        public GetLeadsJob(IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            _configuration = configuration;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                string url = context.JobDetail.JobDataMap.GetString("url");
                string hostKey = context.JobDetail.JobDataMap.GetString("hostKey");
                string token = _configuration["ApiTokens:" + hostKey];
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var apiservice = scope.ServiceProvider.GetService<IRequestService>();

                    await apiservice.GetLeadsAsync(url + "/api/request?status=1", token, httpClient);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Ошибка при вызове API {ex}");
            }
        }
    }
}