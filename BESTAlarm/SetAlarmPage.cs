using System;

using Xamarin.Forms;

namespace BESTAlarm
{
    public class SetAlarmPage : ContentPage
    {

        public SetAlarmPage(TimeSpan customTime)
        {
            Title = "Set Alarm";

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            TimePicker MyTimePicker = new TimePicker
            {
                Time = customTime,
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Label myLabel = new Label
            {
                Text = "Set the alarm here",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            grid.Children.Add(MyTimePicker, 0, 0);
            grid.Children.Add(myLabel, 0, 1);


            Content = new StackLayout
            {
                Children = {
                    grid
                }
            };


        }
    }
}