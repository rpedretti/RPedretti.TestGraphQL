
using System.Net.Http;

namespace RPedretti.TestGraphQL.Web.Services;

public interface IWebApiClient
{
    HttpClient HttpClient { get; }
}

public class WebApiClient : IWebApiClient
{
    public WebApiClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public HttpClient HttpClient { get; }
}
