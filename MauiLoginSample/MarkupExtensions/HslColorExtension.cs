using System.Collections.ObjectModel;
using System.Globalization;

namespace MauiLoginSample.MarkupExtensions
{
    public class HslColorExtension : BindableObject, IMarkupExtension<BindingBase>, IMultiValueConverter
    {
        public static readonly BindableProperty HProperty = BindableProperty.Create(nameof(H), typeof(float), typeof(HslColorExtension));

        public static readonly BindableProperty SProperty = BindableProperty.Create(nameof(S), typeof(float), typeof(HslColorExtension));

        public static readonly BindableProperty LProperty = BindableProperty.Create(nameof(L), typeof(float), typeof(HslColorExtension));

        public static readonly BindableProperty AProperty = BindableProperty.Create(nameof(A), typeof(float), typeof(HslColorExtension));

        public float H
        {
            get { return (float)GetValue(HProperty); }
            set { SetValue(HProperty, value); }
        }

        public float S
        {
            get { return (float)GetValue(SProperty); }
            set { SetValue(SProperty, value); }
        }

        public float L
        {
            get { return (float)GetValue(LProperty); }
            set { SetValue(LProperty, value); }
        }

        public float A
        {
            get { return (float)GetValue(AProperty); }
            set { SetValue(AProperty, value); }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
        }

        BindingBase IMarkupExtension<BindingBase>.ProvideValue(IServiceProvider serviceProvider)
        {
            return new MultiBinding()
            {
                Converter = this,
                Mode = BindingMode.OneWay,
                Bindings = new Collection<BindingBase>
            {
                new Binding(nameof(H), BindingMode.OneWay, null, null, null, this),
                new Binding(nameof(S), BindingMode.OneWay, null, null, null, this),
                new Binding(nameof(L), BindingMode.OneWay, null, null, null, this),
                new Binding(nameof(A), BindingMode.OneWay, null, null, null, this)
            }
            };
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            float H = (float)values[0];
            float S = (float)values[1];
            float L = (float)values[2];
            float A = (float)values[3];

            return Color.FromHsla(H, S, L, A);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
