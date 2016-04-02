using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SideMenu.Controls
{
    public class SelectableBarButtonMenuItem : RadioButton
    {
        static SelectableBarButtonMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectableBarButtonMenuItem), new FrameworkPropertyMetadata(typeof(SelectableBarButtonMenuItem)));
        }

        public ImageSource Icon
        {
            get { return (ImageSource)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(SelectableBarButtonMenuItem), new PropertyMetadata(null));

    }
}
