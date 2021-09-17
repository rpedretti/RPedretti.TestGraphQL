using RPedretti.TestGraphQL.Web.Components.Cms;
using System.Collections.Generic;

namespace RPedretti.TestGraphQL.Web.State;
    public record CmsState(IReadOnlyDictionary<int, CmsItem> Cms, IReadOnlySet<int> Keys);
