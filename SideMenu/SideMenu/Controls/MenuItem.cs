using System.Windows;

namespace SideMenu.Controls
{
    public class LabelMenuItem : OutlinedTextBlock
    {
        static LabelMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabelMenuItem), new FrameworkPropertyMetadata(typeof(LabelMenuItem)));
        }
    }
}
