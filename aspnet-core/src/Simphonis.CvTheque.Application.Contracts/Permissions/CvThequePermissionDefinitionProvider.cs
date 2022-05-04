using Simphonis.CvTheque.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simphonis.CvTheque.Permissions;

public class CvThequePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CvThequePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CvThequePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CvThequeResource>(name);
    }
}
