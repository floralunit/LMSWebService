using LMSWebService;
using LMSWebService.Jobs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Регистрация сервисов
        builder.Services.AddTransient<JobFactory>();
        builder.Services.AddScoped<GetLeadsJob>();
        builder.Services.AddScoped<IRequestService, RequestService>();

        var app = builder.Build();

        // Создание области видимости и запуск планировщика данных
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                DataScheduler.Start(serviceProvider);
            }
            catch (Exception ex)
            {
                // Обработка исключений
                Console.WriteLine($"Ошибка при вызове DataScheduler.Start: {ex.Message}");
                throw;
            }
        }

        app.UseRouting();

        app.Run();
    }
}
