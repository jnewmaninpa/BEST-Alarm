using System;
using BESTAlarm;
using UsingDependencyService.Android;
using Xamarin.Forms;

[assembly: Dependency(typeof(SetAlarmNotification_Android))]
namespace UsingDependencyService.Android
{
    public class SetAlarmNotification_Android : ISetAlarmNotification
    {
        public SetAlarmNotification_Android()
        {
        }

        public void SetAlarm(string name, int hours, int minutes, int seconds)
        {
            throw new NotImplementedException();
        }
    }
}
