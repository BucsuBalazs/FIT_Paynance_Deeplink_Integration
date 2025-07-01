using Android.App;
using Android.Content.PM;
using Android.OS;
using CommunityToolkit.Mvvm.Messaging;
using FIT_Paynance_Deeplink_Integration.Models;

namespace FIT_Paynance_Deeplink_Integration;


[Activity(Theme = "@style/Maui.SplashTheme",
 MainLauncher = true,
 LaunchMode = LaunchMode.SingleTop,
 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { Android.Content.Intent.ActionView },
 Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
 DataScheme = "paynance_intent",
 DataHost = "response")]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnNewIntent(Android.Content.Intent intent)
    {
        base.OnNewIntent(intent);

        var data = intent?.DataString;
        if (!string.IsNullOrEmpty(data))
        {
            Microsoft.Maui.Controls.Application.Current?.Dispatcher.Dispatch(() =>
            {
                WeakReferenceMessenger.Default.Send(new PaymentCallBackMessage(data));
            });
        }

    }
}

