using System;

using Xamarin.Forms;

namespace BESTAlarm
{
    public class SetTimerPage : ContentPage
    {
        public SetTimerPage(TimeSpan customTime)
        {
            Title = "Set Timer";

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            TimePicker MyTimePicker = new TimePicker
            {
                Time = customTime,
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Label myLabel = new Label
            {
                Text = "Set the timer here",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            grid.Children.Add(MyTimePicker, 0, 1);
            grid.Children.Add(myLabel, 0, 0);


            Content = new StackLayout
            {
                Children = {
                    grid
                }
            };
        }
    }
}

