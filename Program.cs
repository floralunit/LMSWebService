using LMSWebService;
using LMSWebService.Jobs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ����������� ��������
        builder.Services.AddTransient<JobFactory>();
        builder.Services.AddScoped<GetLeadsJob>();
        builder.Services.AddScoped<IRequestService, RequestService>();

        var app = builder.Build();

        // �������� ������� ��������� � ������ ������������ ������
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                DataScheduler.Start(serviceProvider);
            }
            catch (Exception ex)
            {
                // ��������� ����������
                Console.WriteLine($"������ ��� ������ DataScheduler.Start: {ex.Message}");
                throw;
            }
        }

        app.UseRouting();

        app.Run();
    }
}
