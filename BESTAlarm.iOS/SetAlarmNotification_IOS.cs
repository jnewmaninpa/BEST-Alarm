﻿using System;
using AudioToolbox;
using BESTAlarm;
using Foundation;
using UIKit;
using UserNotifications;
using UsingDependencyService.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SetAlarmNotification_iOS))]
namespace UsingDependencyService.iOS
{
    public class SetAlarmNotification_iOS : ISetAlarmNotification
    {
        public void CancelAlarm(string id)
        {
            var requests = new string[] { id };
            UNUserNotificationCenter.Current.RemovePendingNotificationRequests(requests);
        }

        public void SetAlarm(String name, int hours, int minutes, int seconds, string id)
        {
            UNMutableNotificationContent content = new UNMutableNotificationContent
            {
                Title = "BEST Alarm - Alarm",
                //Subtitle = "Notification Subtitle",
                Body = name,
                Badge = 1,
                Sound = UNNotificationSound.GetSound("Sounds/service-bell_daniel_simion.mp3")
            };

            NSDateComponents date = new NSDateComponents
            {
                Hour = hours,
                Minute = minutes
            };

            UNCalendarNotificationTrigger trigger = UNCalendarNotificationTrigger.CreateTrigger(date, true);

            string requestID = id;
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
