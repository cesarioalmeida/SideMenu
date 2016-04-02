using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SideMenu.Controls
{
    public class ClickableMenuItem : RadioButton
    {
        static ClickableMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClickableMenuItem), new FrameworkPropertyMetadata(typeof(ClickableMenuItem)));
        }

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ClickableMenuItem), new PropertyMetadata(String.Empty));

        public ImageSource Icon
        {
            get { return (ImageSource)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(ClickableMenuItem), new PropertyMetadata(null));
    }
}
