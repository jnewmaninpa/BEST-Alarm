
using System;
using AudioToolbox;
using Foundation;
using UserNotifications;

namespace BESTAlarm.iOS
{
    public class UserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        #region Constructors
        public UserNotificationCenterDelegate()
        {
        }
        #endregion

        #region Override Methods
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Do something with the notification
            Console.WriteLine("Active Notification: {0}", notification);

            // Tell system to display the notification anyway or use
            // `None` to say we have handled the display locally.
            completionHandler(UNNotificationPresentationOptions.Alert);

            NSUrl url = NSUrl.FromFilename("Sounds/service-bell_daniel_simion.mp3");
            SystemSound ss = new SystemSound(url);
            ss.PlayAlertSound();

        }
        #endregion
    }
}