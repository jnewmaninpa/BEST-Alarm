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

            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Label topLeft = new Label { Text = "Top Left" };
            Label topMiddle = new Label { Text = "Top Right" };
            Label bottomLeft = new Label { Text = "Bottom Left" };
            Label bottomRight = new Label { Text = "Bottom Right" };

            ImageButton topRight = MakeImageButton("house.jpg");
            topRight.Clicked += TopRight_Clicked;

            grid.Children.Add(topLeft, 0, 0);
            grid.Children.Add(topMiddle, 1, 0);
            grid.Children.Add(topRight, 2, 0);
            grid.Children.Add(bottomLeft, 0, 1);
            grid.Children.Add(bottomRight, 1, 1);

            this.Content = grid;
        }

        void TopRight_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MyPage());

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
