namespace SideMenu.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;

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
            new PropertyMetadata(
                null));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(SideMenu),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty IsCollapsibleProperty = DependencyProperty.Register(
            "IsCollapsible",
            typeof(bool),
            typeof(SideMenu),
            new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsCollapsedProperty = DependencyProperty.Register(
            "IsCollapsed",
            typeof(bool),
            typeof(SideMenu),
            new PropertyMetadata(default(bool), OnCollapsedChanged));

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

        public bool IsCollapsed
        {
            get => (bool)this.GetValue(IsCollapsedProperty);
            set => this.SetValue(IsCollapsedProperty, value);
        }

        public bool IsCollapsible
        {
            get => (bool)this.GetValue(IsCollapsibleProperty);
            set => this.SetValue(IsCollapsibleProperty, value);
        }

        public double OriginalWidth { get; private set; }

        public override void BeginInit()
        {
            this.Items = new List<FrameworkElement>();
            this.BarItems = new List<ButtonBase>();
            base.BeginInit();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.OriginalWidth = this.Width;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (this.IsCollapsible)
            {
                this.IsCollapsed = !this.IsCollapsed;
            }
        }

        private static void OnCollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is SideMenu sideMenu) || !(e.NewValue is bool isCollaped))
            {
                return;
            }

            sideMenu.Width = isCollaped ? Math.Max(5, sideMenu.MinWidth) : sideMenu.OriginalWidth;
        }
    }
}