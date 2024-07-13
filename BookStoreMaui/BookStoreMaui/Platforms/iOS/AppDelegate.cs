// using Android.Runtime;

using System.ComponentModel.DataAnnotations;
using CoreSpotlight;
using Foundation;
using UIKit;

namespace BookStoreMaui;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    
    private const string iOsRedirectUri = "boostore://";
    
    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        return base.OpenUrl(app, url, options);
    }

    public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
    {
        // CheckForAppLink(userActivity);
        return true;
    }



    void CheckForAppLink(NSUserActivity userActivity)
    {
        var strLink = string.Empty;

        switch (userActivity.ActivityType)
        {
            case "NSUserActivityTypeBrowsingWeb":
                strLink = userActivity.WebPageUrl.AbsoluteString;
                break;
            case "com.apple.corespotlightitem":
                if (userActivity.UserInfo.ContainsKey(CSSearchableItem.ActivityIdentifier))
                    strLink = userActivity.UserInfo.ObjectForKey(CSSearchableItem.ActivityIdentifier).ToString();
                break;
            default:
                if (userActivity.UserInfo.ContainsKey(new NSString("link")))
                    strLink = userActivity.UserInfo[new NSString("link")].ToString();
                break;
        }

        if (!string.IsNullOrEmpty(strLink))
            App.Current.SendOnAppLinkRequestReceived(new Uri(strLink));
    }
    
    
    
    
}