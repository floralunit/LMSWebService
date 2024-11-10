using Quartz.Impl;
using Quartz;
using System.Data;
using LMSWebService.Jobs;

namespace LMSWebService
{
    public static class DataScheduler
    {

        public static async void Start(IServiceProvider serviceProvider)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
            await scheduler.Start();

            var jobKeyOmodaJaecoo = new JobKey("omoda_jaecoo-job", "default");
            var jobKeyGAC = new JobKey("gac", "default");

            IJobDetail jobDetailOmoda = JobBuilder.Create<GetLeadsJob>()
                .WithIdentity(jobKeyOmodaJaecoo)
                .UsingJobData("url", "omoda-jaecoo.autocrm.ru")
                .UsingJobData("hostKey", "omoda-jaecoo")
                .Build();
            ITrigger triggerOmoda = TriggerBuilder.Create()
                .ForJob(jobKeyOmodaJaecoo)
                .WithIdentity("triggerOmoda", "default")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(40)
                .RepeatForever())
                .Build();


            IJobDetail jobDetailGAC = JobBuilder.Create<GetLeadsJob>()
                .WithIdentity(jobKeyGAC)
                .UsingJobData("url", "gac.autocrm.ru")
                .UsingJobData("hostKey", "gac")
                .Build();

            ITrigger triggerGAC = TriggerBuilder.Create()
                .ForJob(jobKeyGAC)
                .WithIdentity("triggerGAC", "default")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(40)
                .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(jobDetailOmoda, triggerOmoda);
            await scheduler.ScheduleJob(jobDetailGAC, triggerGAC);

        }
    }
}
