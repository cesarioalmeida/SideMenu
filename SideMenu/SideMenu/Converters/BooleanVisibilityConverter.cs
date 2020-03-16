namespace SideMenu.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    public class BooleanVisibilityConverter : MarkupExtension, IValueConverter
    {
        public bool CollapsedInsteadOfHidden { get; set; } = false;

        public bool IsInverted { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool booleanValue))
            {
                return Visibility.Visible;
            }

            return booleanValue ^ this.IsInverted ? Visibility.Visible : this.CollapsedInsteadOfHidden ? Visibility.Collapsed : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }

            return false;
        }
    }
}