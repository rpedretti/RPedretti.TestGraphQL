using RPedretti.TestGraphQL.Web.Components.Cms;
using System;
using System.Collections.Generic;

namespace RPedretti.TestGraphQL.Web.Store.Actions;
public record FetchCmsAction(IEnumerable<CmsItem> Messages, Action? OnComplete = null);
public record FetchCmsActionResult(IEnumerable<CmsItem> Messages, Action? OnComplete);
