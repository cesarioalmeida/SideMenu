namespace SideMenu.Controls
{
    using System.Windows;

    public class LabelMenuItem : OutlinedTextBlock
    {
        static LabelMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(LabelMenuItem),
                new FrameworkPropertyMetadata(typeof(LabelMenuItem)));
        }
    }
}