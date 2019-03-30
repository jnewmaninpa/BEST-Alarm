using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BESTAlarm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "Main Page";

            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });





            // Alarm section title
            Label AlarmTitle = new Label
            {
                Text = "Alarms",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            grid.Children.Add(AlarmTitle, 0, 0);
            Grid.SetColumnSpan(AlarmTitle, 3);


            // Alarm section buttons
            ImageButton alarmButton1 = MakeImageButton("house.jpg");
            alarmButton1.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton1, 0, 1);

            ImageButton alarmButton2 = MakeImageButton("house.jpg");
            alarmButton2.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton2, 1, 1);

            ImageButton alarmButton3 = MakeImageButton("house.jpg");
            alarmButton3.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton3, 2, 1);

            ImageButton alarmButton4 = MakeImageButton("house.jpg");
            alarmButton4.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton4, 0, 2);

            ImageButton alarmButton5 = MakeImageButton("house.jpg");
            alarmButton5.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton5, 1, 2);

            ImageButton alarmButton6 = MakeImageButton("house.jpg");
            alarmButton6.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton6, 2, 2);

            ImageButton alarmButton7 = MakeImageButton("house.jpg");
            alarmButton7.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton7, 0, 3);

            ImageButton alarmButton8 = MakeImageButton("house.jpg");
            alarmButton8.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton8, 1, 3);

            ImageButton alarmButton9 = MakeImageButton("house.jpg");
            alarmButton9.Clicked += AlarmButton_Clicked;
            grid.Children.Add(alarmButton9, 2, 3);

            // Timer section Title
            Label TimerTitle = new Label
            {
                Text = "Timers",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            grid.Children.Add(TimerTitle, 0, 4);
            Grid.SetColumnSpan(TimerTitle, 3);

            // Timer section buttons
            ImageButton timerButton1 = MakeImageButton("house.jpg");
            timerButton1.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton1, 0, 5);

            ImageButton timerButton2 = MakeImageButton("house.jpg");
            timerButton2.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton2, 1, 5);

            ImageButton timerButton3 = MakeImageButton("house.jpg");
            timerButton3.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton3, 2, 5);

            ImageButton timerButton4 = MakeImageButton("house.jpg");
            timerButton4.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton4, 0, 6);

            ImageButton timerButton5 = MakeImageButton("house.jpg");
            timerButton5.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton5, 1, 6);

            ImageButton timerButton6 = MakeImageButton("house.jpg");
            timerButton6.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton6, 2, 6);



            Content = new StackLayout
            {
                Children =
                {
                    grid

                }
            };
        }

        void TimerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetTimerPage(new TimeSpan(17, 0, 0)));
        }


        void AlarmButton_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new SetAlarmPage(new TimeSpan(17,5,0)));

        }

        ImageButton MakeImageButton(String imageName)
        {
            ImageButton TheImageButton = new ImageButton
            {
                Source = imageName,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            return TheImageButton;
        }
    }
}
