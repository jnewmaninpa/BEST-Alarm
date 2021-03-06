﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace BESTAlarm
{
    public interface ISetTimerNotification
    {
        void SetTimer(String name, double timeInSeconds);
    }

    public partial class MainPage : ContentPage
    {
        AlarmInfo myAlarms = new AlarmInfo();

        ImageButton alarmButton1;
        ImageButton alarmButton2;
        ImageButton alarmButton3;
        ImageButton alarmButton4;
        ImageButton alarmButton5;
        ImageButton alarmButton6;
        ImageButton alarmButton7;
        ImageButton alarmButton8;
        ImageButton alarmButton9;

        Button timerButton1;
        Button timerButton2;
        Button timerButton3;
        Button timerButton4;
        Button timerButton5;
        Button timerButton6;

        public MainPage()
        {
            InitializeComponent();



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

            // Alarm section buttons
            alarmButton1 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[0]);
            alarmButton1.Clicked += AlarmButton1_Clicked;
            alarmButton2 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[1]);
            alarmButton2.Clicked += AlarmButton2_Clicked;
            alarmButton3 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[2]);
            alarmButton3.Clicked += AlarmButton3_Clicked;
            alarmButton4 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[3]);
            alarmButton4.Clicked += AlarmButton4_Clicked;
            alarmButton5 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[4]);
            alarmButton5.Clicked += AlarmButton5_Clicked;
            alarmButton6 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[5]);
            alarmButton6.Clicked += AlarmButton6_Clicked;
            alarmButton7 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[6]);
            alarmButton7.Clicked += AlarmButton7_Clicked;
            alarmButton8 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[7]);
            alarmButton8.Clicked += AlarmButton8_Clicked;
            alarmButton9 = MakeImageButton(myAlarms.GetAlarmButtonImageFileName()[8]);
            alarmButton9.Clicked += AlarmButton9_Clicked;

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

            // Timer section buttons
            timerButton1 = new Button
            {
                Text = " 5 Minutes ",
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                BorderWidth = 1
            }; timerButton1.Clicked += TimerButton1_Clicked;
            timerButton2 = new Button
            {
                Text = " 10 Minutes ",
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                BorderWidth = 1
            }; timerButton2.Clicked += TimerButton2_Clicked;
            timerButton3 = new Button
            {
                Text = " 15 Minutes ",
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                BorderWidth = 1
            }; timerButton3.Clicked += TimerButton3_Clicked;
            timerButton4 = new Button
            {
                Text = "30 Minutes",
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                BorderWidth = 1
            }; timerButton4.Clicked += TimerButton4_Clicked;
            timerButton5 = new Button
            {
                Text = "     1 Hour     ",
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                BorderWidth = 1
            }; timerButton5.Clicked += TimerButton5_Clicked;
            timerButton6 = new Button
            {
                Text = "     2 Hours     ",
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.White,
                BorderWidth = 1
            }; timerButton6.Clicked += TimerButton6_Clicked;

            Title = "BEST Alarm";

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

            grid.Children.Add(AlarmTitle, 0, 0);
            Grid.SetColumnSpan(AlarmTitle, 3);

            grid.Children.Add(alarmButton1, 0, 1);
            grid.Children.Add(alarmButton2, 1, 1);
            grid.Children.Add(alarmButton3, 2, 1);
            grid.Children.Add(alarmButton4, 0, 2);
            grid.Children.Add(alarmButton5, 1, 2);
            grid.Children.Add(alarmButton6, 2, 2);
            grid.Children.Add(alarmButton7, 0, 3);
            grid.Children.Add(alarmButton8, 1, 3);
            grid.Children.Add(alarmButton9, 2, 3);

            grid.Children.Add(TimerTitle, 0, 4);
            Grid.SetColumnSpan(TimerTitle, 3);


            grid.Children.Add(timerButton1, 0, 5);
            grid.Children.Add(timerButton2, 1, 5);
            grid.Children.Add(timerButton3, 2, 5);
            grid.Children.Add(timerButton4, 0, 6);
            grid.Children.Add(timerButton5, 1, 6);
            grid.Children.Add(timerButton6, 2, 6);

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
            DependencyService.Get<ISetTimerNotification>().SetTimer("2 Hour Timer", 60 * 60 * 2);
        }

        private void TimerButton5_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISetTimerNotification>().SetTimer("1 Hour Timer", 60 * 60);
        }

        private void TimerButton4_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISetTimerNotification>().SetTimer("30 Minute Timer", 60 * 30);
        }

        private void TimerButton3_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISetTimerNotification>().SetTimer("15 Minute Timer", 60 * 15);
        }

        private void TimerButton2_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISetTimerNotification>().SetTimer("10 Minute Timer", 60 * 10);
        }

        private void TimerButton1_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISetTimerNotification>().SetTimer("5 Minute Timer", 60 * 5);
        }

        override protected void OnAppearing()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");

            if (File.Exists(fileName))
            {
                string temp = File.ReadAllText(fileName);
                Console.WriteLine(temp);

                myAlarms = new AlarmInfo(fileName);

                // If the alarm is on set the background color to green
                // Otherwise the color is clear
                alarmButton1.BackgroundColor = myAlarms.isAlarmButtonOn(0) ? Color.DarkGreen : Color.Transparent;
                alarmButton2.BackgroundColor = myAlarms.isAlarmButtonOn(1) ? Color.DarkGreen : Color.Transparent;
                alarmButton3.BackgroundColor = myAlarms.isAlarmButtonOn(2) ? Color.DarkGreen : Color.Transparent;
                alarmButton4.BackgroundColor = myAlarms.isAlarmButtonOn(3) ? Color.DarkGreen : Color.Transparent;
                alarmButton5.BackgroundColor = myAlarms.isAlarmButtonOn(4) ? Color.DarkGreen : Color.Transparent;
                alarmButton6.BackgroundColor = myAlarms.isAlarmButtonOn(5) ? Color.DarkGreen : Color.Transparent;
                alarmButton7.BackgroundColor = myAlarms.isAlarmButtonOn(6) ? Color.DarkGreen : Color.Transparent;
                alarmButton8.BackgroundColor = myAlarms.isAlarmButtonOn(7) ? Color.DarkGreen : Color.Transparent;
                alarmButton9.BackgroundColor = myAlarms.isAlarmButtonOn(8) ? Color.DarkGreen : Color.Transparent;

                // Make sure the correct images are shown
                alarmButton1.Source = myAlarms.GetAlarmButtonImageFileName()[0];
                alarmButton2.Source = myAlarms.GetAlarmButtonImageFileName()[1];
                alarmButton3.Source = myAlarms.GetAlarmButtonImageFileName()[2];
                alarmButton4.Source = myAlarms.GetAlarmButtonImageFileName()[3];
                alarmButton5.Source = myAlarms.GetAlarmButtonImageFileName()[4];
                alarmButton6.Source = myAlarms.GetAlarmButtonImageFileName()[5];
                alarmButton7.Source = myAlarms.GetAlarmButtonImageFileName()[6];
                alarmButton8.Source = myAlarms.GetAlarmButtonImageFileName()[7];
                alarmButton9.Source = myAlarms.GetAlarmButtonImageFileName()[8];
            }
            else
            {
                myAlarms = new AlarmInfo();
            }
        }

        private void AlarmButton_Clicked(int index)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile");
            myAlarms.SaveToFile(fileName);

            SetAlarmPage newPage = new SetAlarmPage(index);

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
