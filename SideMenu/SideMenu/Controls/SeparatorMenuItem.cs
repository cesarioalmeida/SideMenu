using System.Windows;
using System.Windows.Controls;

namespace SideMenu.Controls
{
    public class SeparatorMenuItem : Control
    {
        static SeparatorMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SeparatorMenuItem), new FrameworkPropertyMetadata(typeof(SeparatorMenuItem)));
        }
    }
}
