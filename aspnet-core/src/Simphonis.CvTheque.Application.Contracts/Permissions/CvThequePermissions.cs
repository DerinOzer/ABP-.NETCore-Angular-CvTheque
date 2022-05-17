namespace Simphonis.CvTheque.Permissions;

public static class CvThequePermissions
{
    public const string GroupName = "CvTheque";

    public static class Candidates
    {
        public const string Default = GroupName + ".Candidates";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
