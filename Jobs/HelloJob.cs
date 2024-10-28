using NLog;
using Quartz;

namespace LMSWebService.Jobs
{
    [DisallowConcurrentExecution]
    public class HelloJob : IJob
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        private readonly IConfiguration _configuration;

        public HelloJob(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                // Вызов API
                var response = await httpClient.GetStringAsync("https://htmlacademy.ru/blog/php/get-vs-post");

                string url = context.JobDetail.JobDataMap.GetString("url");
                string hostKey = context.JobDetail.JobDataMap.GetString("hostKey");
                string token = _configuration["ApiTokens:" + hostKey];

                // Логирование результата
                logger.Info(url + token);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Ошибка при вызове API {ex}");
            }
        }
    }
}
