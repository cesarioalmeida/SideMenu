namespace SideMenu.Controls
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.Windows.Media;

    [ContentProperty("Text")]
    public class OutlinedTextBlock : FrameworkElement
    {
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
            "Fill",
            typeof(Brush),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
            "Stroke",
            typeof(Brush),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
            "StrokeThickness",
            typeof(double),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty FontFamilyProperty = TextElement.FontFamilyProperty.AddOwner(
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontSizeProperty = TextElement.FontSizeProperty.AddOwner(
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontStretchProperty = TextElement.FontStretchProperty.AddOwner(
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontStyleProperty = TextElement.FontStyleProperty.AddOwner(
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontWeightProperty = TextElement.FontWeightProperty.AddOwner(
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextInvalidated));

        public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register(
            "TextAlignment",
            typeof(TextAlignment),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextDecorationsProperty = DependencyProperty.Register(
            "TextDecorations",
            typeof(TextDecorationCollection),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextTrimmingProperty = DependencyProperty.Register(
            "TextTrimming",
            typeof(TextTrimming),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(
            "TextWrapping",
            typeof(TextWrapping),
            typeof(OutlinedTextBlock),
            new FrameworkPropertyMetadata(TextWrapping.NoWrap, OnFormattedTextUpdated));

        private FormattedText _formattedText;

        private Geometry _textGeometry;

        public OutlinedTextBlock()
        {
            this.TextDecorations = new TextDecorationCollection();
        }

        public Brush Fill
        {
            get => (Brush)this.GetValue(FillProperty);
            set => this.SetValue(FillProperty, value);
        }

        public FontFamily FontFamily
        {
            get => (FontFamily)this.GetValue(FontFamilyProperty);
            set => this.SetValue(FontFamilyProperty, value);
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double)this.GetValue(FontSizeProperty);
            set => this.SetValue(FontSizeProperty, value);
        }

        public FontStretch FontStretch
        {
            get => (FontStretch)this.GetValue(FontStretchProperty);
            set => this.SetValue(FontStretchProperty, value);
        }

        public FontStyle FontStyle
        {
            get => (FontStyle)this.GetValue(FontStyleProperty);
            set => this.SetValue(FontStyleProperty, value);
        }

        public FontWeight FontWeight
        {
            get => (FontWeight)this.GetValue(FontWeightProperty);
            set => this.SetValue(FontWeightProperty, value);
        }

        public Brush Stroke
        {
            get => (Brush)this.GetValue(StrokeProperty);
            set => this.SetValue(StrokeProperty, value);
        }

        public double StrokeThickness
        {
            get => (double)this.GetValue(StrokeThicknessProperty);
            set => this.SetValue(StrokeThicknessProperty, value);
        }

        public string Text
        {
            get => (string)this.GetValue(TextProperty);
            set => this.SetValue(TextProperty, value);
        }

        public TextAlignment TextAlignment
        {
            get => (TextAlignment)this.GetValue(TextAlignmentProperty);
            set => this.SetValue(TextAlignmentProperty, value);
        }

        public TextDecorationCollection TextDecorations
        {
            get => (TextDecorationCollection)this.GetValue(TextDecorationsProperty);
            set => this.SetValue(TextDecorationsProperty, value);
        }

        public TextTrimming TextTrimming
        {
            get => (TextTrimming)this.GetValue(TextTrimmingProperty);
            set => this.SetValue(TextTrimmingProperty, value);
        }

        public TextWrapping TextWrapping
        {
            get => (TextWrapping)this.GetValue(TextWrappingProperty);
            set => this.SetValue(TextWrappingProperty, value);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.EnsureFormattedText();

            this._formattedText.MaxTextWidth = finalSize.Width;
            this._formattedText.MaxTextHeight = Math.Max(finalSize.Height, 0.0001d);

            this._textGeometry = null;

            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            this.EnsureFormattedText();

            this._formattedText.MaxTextWidth = Math.Min(3579139, availableSize.Width);
            this._formattedText.MaxTextHeight = Math.Max(0.0001d, availableSize.Height);

            return new Size(this._formattedText.Width, this._formattedText.Height);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            this.EnsureGeometry();

            drawingContext.DrawGeometry(this.Fill, new Pen(this.Stroke, this.StrokeThickness), this._textGeometry);
        }

        private static void OnFormattedTextInvalidated(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            var outlinedTextBlock = (OutlinedTextBlock)dependencyObject;
            outlinedTextBlock._formattedText = null;
            outlinedTextBlock._textGeometry = null;

            outlinedTextBlock.InvalidateMeasure();
            outlinedTextBlock.InvalidateVisual();
        }

        private static void OnFormattedTextUpdated(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            var outlinedTextBlock = (OutlinedTextBlock)dependencyObject;
            outlinedTextBlock.UpdateFormattedText();
            outlinedTextBlock._textGeometry = null;

            outlinedTextBlock.InvalidateMeasure();
            outlinedTextBlock.InvalidateVisual();
        }

        private void EnsureFormattedText()
        {
            if (this._formattedText != null)
            {
                return;
            }

            this._formattedText = new FormattedText(
                this.Text ?? string.Empty,
                CultureInfo.CurrentUICulture,
                this.FlowDirection,
                new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, FontStretches.Normal),
                this.FontSize,
                Brushes.Black);

            this.UpdateFormattedText();
        }

        private void EnsureGeometry()
        {
            if (this._textGeometry != null)
            {
                return;
            }

            this.EnsureFormattedText();
            this._textGeometry = this._formattedText.BuildGeometry(new Point(0, 0));
        }

        private void UpdateFormattedText()
        {
            if (this._formattedText == null)
            {
                return;
            }

            this._formattedText.MaxLineCount = this.TextWrapping == TextWrapping.NoWrap ? 1 : int.MaxValue;
            this._formattedText.TextAlignment = this.TextAlignment;
            this._formattedText.Trimming = this.TextTrimming;

            this._formattedText.SetFontSize(this.FontSize);
            this._formattedText.SetFontStyle(this.FontStyle);
            this._formattedText.SetFontWeight(this.FontWeight);
            this._formattedText.SetFontFamily(this.FontFamily);
            this._formattedText.SetFontStretch(this.FontStretch);
            this._formattedText.SetTextDecorations(this.TextDecorations);
        }
    }
}