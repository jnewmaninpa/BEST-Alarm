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
        Entry myEntry;

        int thisIndex;

        public SetAlarmPage(int index)
        {
            thisIndex = index;

            Title = "Set Alarm";

            BackgroundColor = myAlarms.isAlarmButtonOn(thisIndex) ? Color.DarkGreen : Color.Red;

            MyTimePicker = new TimePicker
            {
                Time = myAlarms.GetAlarmButtonTime()[index],
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White
            };
            MyTimePicker.PropertyChanged += MyTimePicker_PropertyChanged;
            MyTimePicker.IsEnabled = !myAlarms.isAlarmButtonOn(thisIndex);

            myEntry = new Entry
            {
                Text = myAlarms.getAlarmButtonTitle(thisIndex),
                TextColor = Color.Black,
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            myEntry.IsEnabled = !myAlarms.isAlarmButtonOn(thisIndex);
            myEntry.PropertyChanged += MyEntry_PropertyChanged;

            myImage = new ImageButton
            {
                Source = myAlarms.GetAlarmButtonImageFileName()[thisIndex],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("80ccff")
            };
            myImage.Clicked += MyImage_Clicked;
            myImage.IsEnabled = !myAlarms.isAlarmButtonOn(thisIndex);

            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                OnColor = Color.LightGreen,
                IsToggled = myAlarms.isAlarmButtonOn(index)
            };
            switcher.Toggled += Switcher_Toggled;

            alarmOnOffLabel = new Label
            {
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            alarmOnOffLabel.Text = myAlarms.isAlarmButtonOn(thisIndex) ? "The alarm is now on" : "The alarm is now off";

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            grid.Children.Add(myEntry, 0, 1);
            grid.Children.Add(myImage, 0, 2);
            grid.Children.Add(MyTimePicker, 0, 3);
            grid.Children.Add(switcher, 0, 4);
            grid.Children.Add(alarmOnOffLabel, 0, 5);

            Content = new StackLayout
            {
                Children = {
                    grid
                }
            };
        }

        void MyEntry_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                myAlarms.setAlarmButtonTitle(myEntry.Text, thisIndex);
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");
                myAlarms.SaveToFile(fileName);
            }
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

                BackgroundColor = Color.DarkGreen;
                myImage.IsEnabled = false;
                MyTimePicker.IsEnabled = false;
                myEntry.IsEnabled = false;

                DependencyService.Get<ISetAlarmNotification>().SetAlarm(myAlarms.getAlarmButtonTitle(thisIndex), myAlarms.GetAlarmButtonTime()[thisIndex].Hours,
                    myAlarms.GetAlarmButtonTime()[thisIndex].Minutes, myAlarms.GetAlarmButtonTime()[thisIndex].Seconds, myAlarms.getAlarmButtonID(thisIndex));
            }
            else // Switch is now off
            {
                myAlarms.setAlarmButtonOnOff(false, thisIndex);
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");
                myAlarms.SaveToFile(fileName);

                alarmOnOffLabel.Text = "The alarm is now off";

                BackgroundColor = Color.Red;
                myImage.IsEnabled = true;
                MyTimePicker.IsEnabled = true;
                myEntry.IsEnabled = true;

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