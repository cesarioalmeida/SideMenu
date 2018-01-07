namespace SideMenu.Controls
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    public class SideMenu : ContentControl
    {
        public static readonly DependencyProperty BarItemsProperty = DependencyProperty.Register(
            "BarItems",
            typeof(List<ButtonBase>),
            typeof(SideMenu),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items",
            typeof(List<FrameworkElement>),
            typeof(SideMenu),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(SideMenu),
            new PropertyMetadata(default(string)));

        static SideMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SideMenu), new FrameworkPropertyMetadata(typeof(SideMenu)));
        }

        public List<ButtonBase> BarItems
        {
            get => (List<ButtonBase>)this.GetValue(BarItemsProperty);
            set => this.SetValue(BarItemsProperty, value);
        }

        public List<FrameworkElement> Items
        {
            get => (List<FrameworkElement>)this.GetValue(ItemsProperty);
            set => this.SetValue(ItemsProperty, value);
        }

        public string Title
        {
            get => (string)this.GetValue(TitleProperty);
            set => this.SetValue(TitleProperty, value);
        }

        public override void BeginInit()
        {
            this.Items = new List<FrameworkElement>();
            this.BarItems = new List<ButtonBase>();
            base.BeginInit();
        }
    }
}