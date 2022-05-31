using Simphonis.CvTheque.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simphonis.CvTheque.Permissions;

public class CvThequePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var cvThequeGroup = context.AddGroup(CvThequePermissions.GroupName, L("Permission:CvTheque"));

        var skillPermission = cvThequeGroup.AddPermission(CvThequePermissions.Skills.Default, L("Permission:Skills"));
        skillPermission.AddChild(CvThequePermissions.Skills.Create, L("Permission:Skills.Create"));
        skillPermission.AddChild(CvThequePermissions.Skills.Edit, L("Permission:Skills.Edit"));
        skillPermission.AddChild(CvThequePermissions.Skills.Delete, L("Permission:Skills.Delete"));

        var candidatePermission = cvThequeGroup.AddPermission(CvThequePermissions.Candidates.Default, L("Permission:Candidates"));
        candidatePermission.AddChild(CvThequePermissions.Candidates.Create, L("Permission:Candidates.Create"));
        candidatePermission.AddChild(CvThequePermissions.Candidates.Edit, L("Permission:Candidates.Edit"));
        candidatePermission.AddChild(CvThequePermissions.Candidates.Delete, L("Permission:Candidates.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CvThequeResource>(name);
    }
}
