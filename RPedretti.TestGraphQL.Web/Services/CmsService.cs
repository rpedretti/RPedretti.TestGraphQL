using Microsoft.AspNetCore.Components;
using RPedretti.TestGraphQL.Types;
using RPedretti.TestGraphQL.Web.Components.Cms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace RPedretti.TestGraphQL.Web.Services;

public class CmsService : ICmsService
{
    private const string _controller = "/api/cms";

    private readonly ICmsSelector cmsSelector;
    private readonly NavigationManager navigationManager;
    private readonly HttpClient _httpClient;

    public CmsService(ICmsSelector cmsSelector, NavigationManager navigationManager, IWebApiClient httpClient)
    {
        this.cmsSelector = cmsSelector;
        this.navigationManager = navigationManager;
        this._httpClient = httpClient.HttpClient;
    }

    public async Task<IEnumerable<CmsItem>> FetchCmsAsync(IEnumerable<CmsItem> items)
    {
        var uriQuery = HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
        uriQuery.Set("languageId", uriQuery.Get("languageId") ?? "1");
        var query = $"?cmsIds={string.Join(",", items.Select(i => i.Id))}";
        var messages = await _httpClient.GetFromJsonAsync<IEnumerable<CmsItemType>>($"{_controller}/cms{query}&{uriQuery}");
        return messages?.Select(m => new CmsItem(m.CmsId!.Value, m.Text!)) ?? new List<CmsItem>();
    }

    public string Get(CmsItem cmsItem, params object?[] args) => string.Format(cmsSelector[cmsItem].Text, args);
}
