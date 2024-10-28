
using LMSWebService.Jobs;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Logging;
using Quartz;

var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

NLog.ILogger logger = LogManager.GetCurrentClassLogger();
// Настройка NLog
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddNLog();
});

loggerFactory.ConfigureNLog("nlog.config");
logger.Info("Запуск приложения...");


var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((cxt, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();
            var jobKey = new JobKey("myJob", "group1");
            q.AddJob<HelloJob>(opts => opts
            .WithIdentity(jobKey)
            .UsingJobData("url", "http://omoda-jaecoo/")
            .UsingJobData("hostKey", "omoda-jaecoo"));

            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("myTrigger", "group1")
               .StartNow()
  .WithSimpleSchedule(x => x
   .WithIntervalInSeconds(40)
   .RepeatForever()));

        });
        services.AddQuartzHostedService(opt =>
        {
            opt.WaitForJobsToComplete = true;
        });
    }).Build();

var schedulerFactory = builder.Services.GetRequiredService<ISchedulerFactory>();
var scheduler = await schedulerFactory.GetScheduler();


// will block until the last running job completes
await builder.RunAsync();
