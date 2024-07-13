namespace BookStoreAbpApi.Permissions;

public static class BookStoreAbpApiPermissions
{
    public const string GroupName = "BookStoreAbpApi";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Books
    {
        public const string Default = GroupName + ".BookStoreAbpApi";
        public const string Create = Default + ".Create";
        public const string Update = Default+ ".Update";
        public const string Delete = Default + ".Delete";
    }   


    public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = Default + ".Create";
        public const string Update = Default+ ".Update";
        public const string Delete = Default + ".Delete";
    }
}
