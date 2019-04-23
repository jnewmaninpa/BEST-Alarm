using System;
using AudioToolbox;
using BESTAlarm;
using Foundation;
using UIKit;
using UserNotifications;
using UsingDependencyService.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SetTimerNotification_iOS))]
namespace UsingDependencyService.iOS
{
    public class SetTimerNotification_iOS : ISetTimerNotification
    {

        public void SetTimer(String name, double timeInSeconds)
        {
            UNMutableNotificationContent content = new UNMutableNotificationContent
            {
                Title = "BEST Alarm - Timer",
                //Subtitle = "Notification Subtitle",
                Body = name,
                Badge = 1,
                Sound = UNNotificationSound.GetSound("Sounds/service-bell_daniel_simion.mp3")
            };

            UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(timeInSeconds, false);

            string requestID = name;
            UNNotificationRequest request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            // Get current notification settings
            UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
                var alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            });

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            {
                if (err != null)
                {
                    // Do something with error...
                }
            });
        }
    }

}
