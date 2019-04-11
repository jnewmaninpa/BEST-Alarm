using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace BESTAlarm
{
    public interface ISetAlarmNotification
    {
        void SetAlarm(String name, int hours, int minutes, int seconds, String id);
        void CancelAlarm(String id);
    }



    public class SetAlarmPage : ContentPage
    {
        AlarmInfo myAlarms = new AlarmInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile"));

        TimePicker MyTimePicker;
        Label alarmOnOffLabel;
        ImageButton myImage;

        int thisIndex;

        public SetAlarmPage(int index)
        {
            Title = "Set Alarm";

            thisIndex = index;

            BackgroundColor = Color.FromHex("80ccff");

            MyTimePicker = new TimePicker
            {
                Time = myAlarms.GetAlarmButtonTime()[index],
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White
            };
            MyTimePicker.PropertyChanged += MyTimePicker_PropertyChanged;

            Label myLabel = new Label
            {
                Text = "Set the alarm here",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            myImage = new ImageButton
            {
                Source = myAlarms.GetAlarmButtonImageFileName()[thisIndex],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            myImage.Clicked += MyImage_Clicked;

            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                OnColor = Color.DarkGreen,
                IsToggled = myAlarms.isAlarmButtonOn(index)
            };
            switcher.Toggled += Switcher_Toggled;

            alarmOnOffLabel = new Label
            {
                Text = "The alarm is off",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            grid.Children.Add(myImage, 0, 0);
            grid.Children.Add(myLabel, 0, 1);
            grid.Children.Add(MyTimePicker, 0, 2);
            grid.Children.Add(switcher, 0, 3);
            grid.Children.Add(alarmOnOffLabel, 0, 4);

            Content = new StackLayout
            {
                Children = {
                    grid
                }
            };
        }

        override protected void OnAppearing()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");

            if (File.Exists(fileName))
            {
                string temp = File.ReadAllText(fileName);
                Console.WriteLine(temp);

                myAlarms = new AlarmInfo(fileName);

                // Make sure the correct image is shown
                myImage.Source = myAlarms.GetAlarmButtonImageFileName()[thisIndex];
            }
            else
            {
                myAlarms = new AlarmInfo();
            }
        }

        void MyImage_Clicked(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");
            myAlarms.SaveToFile(fileName);

            PictureSelector newPage = new PictureSelector(thisIndex);

            Navigation.PushAsync(newPage);
        }


        private void Switcher_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value) // Switch is now on
            {
                myAlarms.setAlarmButtonOnOff(true, thisIndex);
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");
                myAlarms.SaveToFile(fileName);

                alarmOnOffLabel.Text = "The alarm is now on";
                alarmOnOffLabel.TextColor = Color.DarkGreen;

                DependencyService.Get<ISetAlarmNotification>().SetAlarm("test notification", myAlarms.GetAlarmButtonTime()[thisIndex].Hours,
                    myAlarms.GetAlarmButtonTime()[thisIndex].Minutes, myAlarms.GetAlarmButtonTime()[thisIndex].Seconds, myAlarms.getAlarmButtonID(thisIndex));
            }
            else // Switch is now off
            {
                myAlarms.setAlarmButtonOnOff(false, thisIndex);
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");
                myAlarms.SaveToFile(fileName);
                alarmOnOffLabel.Text = "The alarm is now off";
                alarmOnOffLabel.TextColor = Color.Red;

                DependencyService.Get<ISetAlarmNotification>().CancelAlarm(myAlarms.getAlarmButtonID(thisIndex));
            }
        }

        void MyTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                myAlarms.SetAlarmButtonTime(MyTimePicker.Time, thisIndex);
                myAlarms.SetAlarmButtonTime(myAlarms.GetAlarmButtonTime()[thisIndex], thisIndex);
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");
                myAlarms.SaveToFile(fileName);

            }
        }
    }
}