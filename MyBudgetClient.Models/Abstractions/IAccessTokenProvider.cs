namespace MyBudgetClient.Models.Abstractions;

public interface IAccessTokenProvider
{
    Task<string> GetAccessToken();
}