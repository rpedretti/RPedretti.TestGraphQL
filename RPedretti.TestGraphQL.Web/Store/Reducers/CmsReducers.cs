using Fluxor;
using RPedretti.TestGraphQL.Web.Store.Actions;
using System.Linq;

namespace RPedretti.TestGraphQL.Web.State.Reducers
{
    public class CmsReducers
    {
        [ReducerMethod]
        public static CmsState ReduceFetchCmsActionResult(CmsState state, FetchCmsActionResult action)
        {
            var newState = state with { Cms = action.Messages.ToDictionary(m => m.Id), Keys = action.Messages.Select(m => m.Id).ToHashSet() };
            action.OnComplete?.Invoke();

            return newState;
        }
    }
}
