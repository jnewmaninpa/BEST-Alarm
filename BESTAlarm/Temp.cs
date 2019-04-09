using System;
using System.ComponentModel;
using Xamarin.Forms;

using Xamarin.Forms;

namespace BESTAlarm
{
    public class Temp : ContentPage
    {
        String imageName;
        TimeSpan customTime;
        TimePicker MyTimePicker;
        Label alarmOnOffLabel;

        public Temp(String newImageName, TimeSpan newCustomTime)
        {
            Title = "Set Alarm";
            BackgroundColor = Color.DarkGreen;

            imageName = newImageName;
            customTime = newCustomTime;

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            MyTimePicker = new TimePicker
            {
                Time = customTime,
                FontSize = 50,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
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

            Image myImage = new Image
            {
                Source = imageName,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            switcher.Toggled += Switcher_Toggled;

            alarmOnOffLabel = new Label
            {
                Text = "The alarm is off",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

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

        private void Switcher_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value) // Switch is now on
            {
                alarmOnOffLabel.Text = "The alarm is now on";
                BackgroundColor = Color.DarkGreen;
            }
            else // Switch is now off
            {
                alarmOnOffLabel.Text = "The alarm is now off";
                BackgroundColor = Color.Red;
            }
        }

        void MyTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                customTime = MyTimePicker.Time;

            }
        }
    }
}

