using MyBudgetClient.Models.Abstractions;

namespace MyBudgetClient.Mcp;

public class EnvironmentVariableAccessTokenProvider : IAccessTokenProvider
{
    public Task<string> GetAccessToken() => Task.FromResult(Environment.GetEnvironmentVariable("MYBUDGET_TOKEN") ?? throw new NullReferenceException("Access token environment variable is not set"));
}