namespace RPedretti.TestGraphQL.Web.Components.Cms;

public interface ICmsSelector
{
    CmsItem this[CmsItem cms]
    {
        get;
    }
}
