namespace SideMenu.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class ClickableMenuItem : RadioButton
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(ImageSource),
            typeof(ClickableMenuItem),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(ClickableMenuItem),
            new PropertyMetadata(string.Empty));

        static ClickableMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ClickableMenuItem),
                new FrameworkPropertyMetadata(typeof(ClickableMenuItem)));
        }

        public ImageSource Icon
        {
            get => (ImageSource)this.GetValue(IconProperty);
            set => this.SetValue(IconProperty, value);
        }

        public string Text
        {
            get => (string)this.GetValue(TextProperty);
            set => this.SetValue(TextProperty, value);
        }
    }
}