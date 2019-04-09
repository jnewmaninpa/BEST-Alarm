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

        AlarmInfo myAlarms = new AlarmInfo();

        public MainPage()
        {
            InitializeComponent();

            myAlarms.SetAlarmButtonImageFileName(new String[9]);
            myAlarms.SetAlarmButtonTime(new TimeSpan[9]);

            myAlarms.SetAlarmButtonImageFileName("toothbrush.png", 0);
            myAlarms.SetAlarmButtonTime(new TimeSpan(7, 0, 0), 0);

            myAlarms.SetAlarmButtonImageFileName("shirt.png", 1);
            myAlarms.SetAlarmButtonTime(new TimeSpan(7, 5, 0), 1);
            myAlarms.SetAlarmButtonImageFileName("bed.png", 2);
            myAlarms.SetAlarmButtonTime(new TimeSpan(21, 30, 0), 2);
            myAlarms.SetAlarmButtonImageFileName("snitch.png", 3);
            myAlarms.SetAlarmButtonTime(new TimeSpan(16, 0, 0), 3);
            myAlarms.SetAlarmButtonImageFileName("cloud.png", 4);
            myAlarms.SetAlarmButtonTime(new TimeSpan(7, 45, 0), 4);
            myAlarms.SetAlarmButtonImageFileName("wrench.png", 5);
            myAlarms.SetAlarmButtonTime(new TimeSpan(13, 0, 0), 5);
            myAlarms.SetAlarmButtonImageFileName("plate.png", 6);
            myAlarms.SetAlarmButtonTime(new TimeSpan(12, 0, 0), 6);
            myAlarms.SetAlarmButtonImageFileName("sleep.png", 7);
            myAlarms.SetAlarmButtonTime(new TimeSpan(17, 0, 0), 7);
            myAlarms.SetAlarmButtonImageFileName("car.png", 8);
            myAlarms.SetAlarmButtonTime(new TimeSpan(15, 30, 0), 8);


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
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center
                
            };

            grid.Children.Add(AlarmTitle, 0, 0);
            Grid.SetColumnSpan(AlarmTitle, 3);


            // Alarm section buttons
            ImageButton alarmButton1 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[0]);
            alarmButton1.Clicked += AlarmButton1_Clicked;
            grid.Children.Add(alarmButton1, 0, 1);


            ImageButton alarmButton2 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[1]);
            alarmButton2.Clicked += AlarmButton2_Clicked;
            grid.Children.Add(alarmButton2, 1, 1);

            ImageButton alarmButton3 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[2]);
            alarmButton3.Clicked += AlarmButton3_Clicked;
            grid.Children.Add(alarmButton3, 2, 1);

            ImageButton alarmButton4 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[3]);
            alarmButton4.Clicked += AlarmButton4_Clicked;
            grid.Children.Add(alarmButton4, 0, 2);

            ImageButton alarmButton5 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[4]);
            alarmButton5.Clicked += AlarmButton5_Clicked;
            grid.Children.Add(alarmButton5, 1, 2);

            ImageButton alarmButton6 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[5]);
            alarmButton6.Clicked += AlarmButton6_Clicked;
            grid.Children.Add(alarmButton6, 2, 2);

            ImageButton alarmButton7 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[6]);
            alarmButton7.Clicked += AlarmButton7_Clicked;
            grid.Children.Add(alarmButton7, 0, 3);

            ImageButton alarmButton8 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[7]);
            alarmButton8.Clicked += AlarmButton8_Clicked;
            grid.Children.Add(alarmButton8, 1, 3);

            ImageButton alarmButton9 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[8]);
            alarmButton9.Clicked += AlarmButton9_Clicked;
            grid.Children.Add(alarmButton9, 2, 3);

            // Timer section Title
            Label TimerTitle = new Label
            {
                Text = "Timers",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center
            };

            grid.Children.Add(TimerTitle, 0, 4);
            Grid.SetColumnSpan(TimerTitle, 3);

            // Timer section buttons
            ImageButton timerButton1 = MakeImageButton("cloud.png");
            timerButton1.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton1, 0, 5);

            ImageButton timerButton2 = MakeImageButton("cloud.png");
            timerButton2.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton2, 1, 5);

            ImageButton timerButton3 = MakeImageButton("cloud.png");
            timerButton3.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton3, 2, 5);

            ImageButton timerButton4 = MakeImageButton("cloud.png");
            timerButton4.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton4, 0, 6);

            ImageButton timerButton5 = MakeImageButton("cloud.png");
            timerButton5.Clicked += TimerButton_Clicked;
            grid.Children.Add(timerButton5, 1, 6);

            ImageButton timerButton6 = MakeImageButton("cloud.png");
            timerButton6.Clicked += TimerButton6_Clicked;
            grid.Children.Add(timerButton6, 2, 6);
            timerButton6.BackgroundColor = Color.DarkGreen;



            Content = new StackLayout
            {
                Children =
                {
                    grid
                }

            };
        }

        private void TimerButton6_Clicked(object sender, EventArgs e)
        {
            myAlarms.SaveToFile();

            Temp newPage = new Temp(myAlarms.GetAlarmButtonImageFileName()[4], myAlarms.GetAlarmButtonTime()[4])
            {
                BindingContext = myAlarms
            };

            Navigation.PushAsync(newPage);
        }

        private void AlarmButton_Clicked(int index)
        {
            myAlarms.SaveToFile();

            SetAlarmPage newPage = new SetAlarmPage(myAlarms.GetAlarmButtonImageFileName()[index], myAlarms.GetAlarmButtonTime()[index])
            {
                BindingContext = myAlarms
            };

            Navigation.PushAsync(newPage);
        }

        private void AlarmButton1_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(0);
        }

        private void AlarmButton2_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(1);
        }

        private void AlarmButton3_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(2);
        }

        private void AlarmButton4_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(3);
        }

        private void AlarmButton5_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(4);
        }

        private void AlarmButton6_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(5);
        }

        private void AlarmButton7_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(6);
        }

        private void AlarmButton8_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(7);
        }

        private void AlarmButton9_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(8);
        }

        void TimerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetTimerPage(new TimeSpan(17, 0, 0)));
        }

        ImageButton MakeImageButton(String imageName)
        {
            ImageButton TheImageButton = new ImageButton
            {
                Source = imageName,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                BorderWidth = 1
            };

            return TheImageButton;
        }

    }
}
