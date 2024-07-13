using BookStoreAbpApi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookStoreAbpApi.Permissions;

public class BookStoreAbpApiPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookStoreAbpApiPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStoreAbpApiPermissions.MyPermission1, L("Permission:MyPermission1"));


        var booksPermission = myGroup.AddPermission(BookStoreAbpApiPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BookStoreAbpApiPermissions.Books.Create, L("Permission:Books:Create"));
        booksPermission.AddChild(BookStoreAbpApiPermissions.Books.Update, L("Permission:Books:Update"));
        booksPermission.AddChild(BookStoreAbpApiPermissions.Books.Delete, L("Permission:Books:Delete"));
        
        //"Permission:Books": "Books management",
        //"Permission:Books:Create": "Creating books",
        //"Permission:Books:Update": "Editing books",
        //"Permission:Books:Delete": "Deleting books",

        var authorsPermission = myGroup.AddPermission(BookStoreAbpApiPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(BookStoreAbpApiPermissions.Authors.Create, L("Permission:Authors:Create"));
        authorsPermission.AddChild(BookStoreAbpApiPermissions.Authors.Update, L("Permission:Authors:Update"));
        authorsPermission.AddChild(BookStoreAbpApiPermissions.Authors.Delete, L("Permission:Authors:Delete"));
        
        //"Permission:Authors": "Authors management",
        //"Permission:Authors:Create": "Creating Authors",
        //"Permission:Authors:Update": "Editing Authors",
        //"Permission:Authors:Delete": "Deleting Authors",
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreAbpApiResource>(name);
    }
}
