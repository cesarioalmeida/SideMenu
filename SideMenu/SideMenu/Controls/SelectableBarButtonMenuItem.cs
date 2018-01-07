namespace SideMenu.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class SelectableBarButtonMenuItem : RadioButton
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(ImageSource),
            typeof(SelectableBarButtonMenuItem),
            new PropertyMetadata(null));

        static SelectableBarButtonMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SelectableBarButtonMenuItem),
                new FrameworkPropertyMetadata(typeof(SelectableBarButtonMenuItem)));
        }

        public ImageSource Icon
        {
            get => (ImageSource)this.GetValue(IconProperty);
            set => this.SetValue(IconProperty, value);
        }
    }
}