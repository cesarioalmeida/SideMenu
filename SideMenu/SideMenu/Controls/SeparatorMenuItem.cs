namespace SideMenu.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    public class SeparatorMenuItem : Control
    {
        static SeparatorMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SeparatorMenuItem),
                new FrameworkPropertyMetadata(typeof(SeparatorMenuItem)));
        }
    }
}