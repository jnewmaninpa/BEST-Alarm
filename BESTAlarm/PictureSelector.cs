using System;
using System.IO;
using Xamarin.Forms;

namespace BESTAlarm
{
    public class PictureSelector : ContentPage
    {
        AlarmInfo myAlarms = new AlarmInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile"));

        private readonly string[] imageFileNames =
            { 
            "bed.png", "car.png", "plate.png",
            "shirt.png", "sleep.png", "snitch.png",
            "toothbrush.png", "wrench.png", "cloud.png",
            "ball.png", "bat.png", "bath.png",
            "bedsleeping.png", "cookiemonster.png", "harrypotter.png",
            "plane.png", "plant.png", "sun.png",
            "watermelon.png", "snow.png", "monster.png"
            };

        ImageButton alarmButton1;
        ImageButton alarmButton2;
        ImageButton alarmButton3;
        ImageButton alarmButton4;
        ImageButton alarmButton5;
        ImageButton alarmButton6;
        ImageButton alarmButton7;
        ImageButton alarmButton8;
        ImageButton alarmButton9;
        ImageButton alarmButton10;
        ImageButton alarmButton11;
        ImageButton alarmButton12;
        ImageButton alarmButton13;
        ImageButton alarmButton14;
        ImageButton alarmButton15;
        ImageButton alarmButton16;
        ImageButton alarmButton17;
        ImageButton alarmButton18;
        ImageButton alarmButton19;
        ImageButton alarmButton20;
        ImageButton alarmButton21;

        int thisIndex;

        public PictureSelector(int index)
        {
            thisIndex = index;

            Title = "Picture Selector";

            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Alarm section buttons
            alarmButton1 = MakeImageButton(imageFileNames[0]);
            alarmButton1.Clicked += AlarmButton1_Clicked;
            grid.Children.Add(alarmButton1, 0, 0);

            alarmButton2 = MakeImageButton(imageFileNames[1]);
            alarmButton2.Clicked += AlarmButton2_Clicked;
            grid.Children.Add(alarmButton2, 1, 0);

            alarmButton3 = MakeImageButton(imageFileNames[2]);
            alarmButton3.Clicked += AlarmButton3_Clicked;
            grid.Children.Add(alarmButton3, 2, 0);

            alarmButton4 = MakeImageButton(imageFileNames[3]);
            alarmButton4.Clicked += AlarmButton4_Clicked;
            grid.Children.Add(alarmButton4, 0, 1);

            alarmButton5 = MakeImageButton(imageFileNames[4]);
            alarmButton5.Clicked += AlarmButton5_Clicked;
            grid.Children.Add(alarmButton5, 1, 1);

            alarmButton6 = MakeImageButton(imageFileNames[5]);
            alarmButton6.Clicked += AlarmButton6_Clicked;
            grid.Children.Add(alarmButton6, 2, 1);

            alarmButton7 = MakeImageButton(imageFileNames[6]);
            alarmButton7.Clicked += AlarmButton7_Clicked;
            grid.Children.Add(alarmButton7, 0, 2);

            alarmButton8 = MakeImageButton(imageFileNames[7]);
            alarmButton8.Clicked += AlarmButton8_Clicked;
            grid.Children.Add(alarmButton8, 1, 2);

            alarmButton9 = MakeImageButton(imageFileNames[8]);
            alarmButton9.Clicked += AlarmButton9_Clicked;
            grid.Children.Add(alarmButton9, 2, 2);

            alarmButton10 = MakeImageButton(imageFileNames[9]);
            alarmButton10.Clicked += AlarmButton10_Clicked;
            grid.Children.Add(alarmButton10, 0, 3);

            alarmButton11 = MakeImageButton(imageFileNames[10]);
            alarmButton11.Clicked += AlarmButton11_Clicked;
            grid.Children.Add(alarmButton11, 1, 3);

            alarmButton12 = MakeImageButton(imageFileNames[11]);
            alarmButton12.Clicked += AlarmButton12_Clicked;
            grid.Children.Add(alarmButton12, 2, 3);

            alarmButton13 = MakeImageButton(imageFileNames[12]);
            alarmButton13.Clicked += AlarmButton13_Clicked;
            grid.Children.Add(alarmButton13, 0, 4);

            alarmButton14 = MakeImageButton(imageFileNames[13]);
            alarmButton14.Clicked += AlarmButton14_Clicked;
            grid.Children.Add(alarmButton14, 1, 4);

            alarmButton15 = MakeImageButton(imageFileNames[14]);
            alarmButton15.Clicked += AlarmButton15_Clicked;
            grid.Children.Add(alarmButton15, 2, 4);

            alarmButton16 = MakeImageButton(imageFileNames[15]);
            alarmButton16.Clicked += AlarmButton16_Clicked;
            grid.Children.Add(alarmButton16, 0, 5);

            alarmButton17 = MakeImageButton(imageFileNames[16]);
            alarmButton17.Clicked += AlarmButton17_Clicked;
            grid.Children.Add(alarmButton17, 1, 5);

            alarmButton18 = MakeImageButton(imageFileNames[17]);
            alarmButton18.Clicked += AlarmButton18_Clicked;
            grid.Children.Add(alarmButton18, 2, 5);

            alarmButton19 = MakeImageButton(imageFileNames[18]);
            alarmButton19.Clicked += AlarmButton19_Clicked;
            grid.Children.Add(alarmButton19, 0, 6);

            alarmButton20 = MakeImageButton(imageFileNames[19]);
            alarmButton20.Clicked += AlarmButton20_Clicked;
            grid.Children.Add(alarmButton20, 1, 6);

            alarmButton21 = MakeImageButton(imageFileNames[20]);
            alarmButton21.Clicked += AlarmButton21_Clicked;
            grid.Children.Add(alarmButton21, 2, 6);


            Content = new StackLayout
            {
                Children =
                {
                    grid
                }

            };
        }

        private void AlarmButton_Clicked(int buttonNumber)
        {
            myAlarms.SetAlarmButtonImageFileName(imageFileNames[buttonNumber], thisIndex);

            myAlarms.SaveToFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempFile"));

            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void AlarmButton21_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(20);
        }

        private void AlarmButton20_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(19);
        }

        private void AlarmButton19_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(18);
        }

        private void AlarmButton18_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(17);
        }

        private void AlarmButton17_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(16);
        }

        private void AlarmButton16_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(15);
        }

        private void AlarmButton15_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(14);
        }

        private void AlarmButton14_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(13);
        }

        private void AlarmButton13_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(12);
        }

        private void AlarmButton12_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(11);
        }

        private void AlarmButton11_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(10);
        }

        private void AlarmButton10_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(9);
        }

        private void AlarmButton9_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(8);
        }

        private void AlarmButton8_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(7);
        }

        private void AlarmButton7_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(6);
        }

        private void AlarmButton6_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(5);
        }

        private void AlarmButton5_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(4);
        }

        private void AlarmButton4_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(3);
        }

        private void AlarmButton3_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(2);
        }

        private void AlarmButton2_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(1);
        }

        private void AlarmButton1_Clicked(object sender, EventArgs e)
        {
            AlarmButton_Clicked(0);
        }

        ImageButton MakeImageButton(String imageName)
        {
            ImageButton TheImageButton = new ImageButton
            {
                Source = imageName,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BorderColor = Color.Black,
                BorderWidth = 1
            };
            return TheImageButton;
        }
    }
}

