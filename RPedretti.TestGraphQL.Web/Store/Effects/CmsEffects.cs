using Fluxor;
using RPedretti.TestGraphQL.Web.Services;
using RPedretti.TestGraphQL.Web.Store.Actions;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.Web.State.Effects
{
    public class FetchCmsActionEffect : Effect<FetchCmsAction>
    {
		private readonly ICmsService cmsService;

		public FetchCmsActionEffect(ICmsService cmsService)
		{
			this.cmsService = cmsService;
		}

        public override async Task HandleAsync(FetchCmsAction action, IDispatcher dispatcher)
        {
            var messages = await cmsService.FetchCmsAsync(action.Messages);
            dispatcher.Dispatch(new FetchCmsActionResult(messages, action.OnComplete));
        }

    }
}
