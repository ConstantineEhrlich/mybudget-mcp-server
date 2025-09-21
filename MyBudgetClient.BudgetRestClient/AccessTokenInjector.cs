using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using MyBudgetClient.Models.Abstractions;

namespace MyBudgetClient.BudgetRestClient;

public class AccessTokenInjector : DelegatingHandler
{
    private readonly ILogger<AccessTokenInjector> _logger;
    private readonly IAccessTokenProvider _tokenProvider;

    public AccessTokenInjector(ILogger<AccessTokenInjector> logger, IAccessTokenProvider accessTokenProvider)
    {
        _logger = logger;
        _tokenProvider = accessTokenProvider;
    }
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Requesting access token");
        var token = await _tokenProvider.GetAccessToken();
        if (string.IsNullOrWhiteSpace(token))
            throw new InvalidOperationException("Access token is null or empty");
            
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await base.SendAsync(request, cancellationToken);
        return response;
    }
}