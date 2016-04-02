using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SideMenu.Controls
{
    public class BarButtonMenuItem : Button
    {
        static BarButtonMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BarButtonMenuItem), new FrameworkPropertyMetadata(typeof(BarButtonMenuItem)));
        }

        public ImageSource Icon
        {
            get { return (ImageSource)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(BarButtonMenuItem), new PropertyMetadata(null));

    }
}
