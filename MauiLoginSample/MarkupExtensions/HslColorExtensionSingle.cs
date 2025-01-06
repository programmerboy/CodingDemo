using System.Globalization;

namespace MauiLoginSample.MarkupExtensions
{
    public class HslColorExtensionSingle : BindableObject, IMarkupExtension<BindingBase>, IValueConverter
    {
        public static readonly BindableProperty HProperty = BindableProperty.Create(nameof(H), typeof(float), typeof(HslColorExtensionSingle));

        public float H
        {
            get { return (float)GetValue(HProperty); }
            set { SetValue(HProperty, value); }
        }

        public float S { get; set; }
        public float L { get; set; }
        public float A { get; set; } = 1.0f;

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
        }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            return new Binding(nameof(H), BindingMode.OneWay, this, null, null, this);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            float H = (float)value;
            return Color.FromHsla(H, S, L, A);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
