using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SideMenu.Controls
{
    public class SideMenu : ContentControl
    {
        static SideMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SideMenu), new FrameworkPropertyMetadata(typeof(SideMenu)));
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(List<FrameworkElement>), typeof(SideMenu),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public List<FrameworkElement> Items
        {
            get { return (List<FrameworkElement>)this.GetValue(ItemsProperty); }
            set { this.SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty BarItemsProperty =
            DependencyProperty.Register("BarItems", typeof(List<ButtonBase>), typeof(SideMenu),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public List<ButtonBase> BarItems
        {
            get { return (List<ButtonBase>)this.GetValue(BarItemsProperty); }
            set { this.SetValue(BarItemsProperty, value); }
        }

        public override void BeginInit()
        {
            this.Items = new List<FrameworkElement>();
            this.BarItems = new List<ButtonBase>();
            base.BeginInit();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SideMenu), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }
    }
}
