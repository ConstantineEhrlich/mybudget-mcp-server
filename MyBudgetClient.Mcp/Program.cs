using MyBudgetClient.BudgetRestClient;
using MyBudgetClient.Models.Abstractions;
using MyBudgetClient.Models.Configuration;

namespace MyBudgetClient.Mcp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);
        var app = builder.Build();
        app.MapMcp();
        await app.RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging();
        services.AddTransient<IAccessTokenProvider, EnvironmentVariableAccessTokenProvider>()
                .AddTransient<AccessTokenInjector>()
                .AddClient<IBudgetFileClient, BudgetFileClient>(configuration)
                .AddClient<ICategoryClient, CategoryClient>(configuration)
                .AddClient<ITransactionClient, TransactionClient>(configuration);
        
        services.AddMcpServer()
            .WithTools<MyBudgetTools>()
            .WithHttpTransport();
    }
}

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClient<TInterface, TImplementation>(this IServiceCollection services, IConfiguration configuration)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        var apiConfig = configuration.GetSection(nameof(BudgetApiConfiguration)).Get<BudgetApiConfiguration>();
        services.AddHttpClient<TInterface, TImplementation>(ConfigureClient(apiConfig))
                .AddHttpMessageHandler<AccessTokenInjector>();
        return services;
    }

    private static Action<HttpClient> ConfigureClient(BudgetApiConfiguration? apiConfig) => client =>
    {
        if (apiConfig is null)
            throw new InvalidOperationException("Missing BudgetApiConfiguration");
        if (apiConfig.BaseUrl is null)
            throw new InvalidOperationException("Missing BaseUrl in BudgetApiConfiguration");
        client.BaseAddress = apiConfig.BaseUrl;
    };
}