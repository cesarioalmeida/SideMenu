namespace SideMenu.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class BarButtonMenuItem : Button
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(BarButtonMenuItem), new PropertyMetadata(null));

        static BarButtonMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BarButtonMenuItem), new FrameworkPropertyMetadata(typeof(BarButtonMenuItem)));
        }

        public ImageSource Icon
        {
            get => (ImageSource)this.GetValue(IconProperty);
            set => this.SetValue(IconProperty, value);
        }
    }
}
