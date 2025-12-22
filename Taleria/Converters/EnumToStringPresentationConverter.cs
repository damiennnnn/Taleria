using Avalonia.Data.Converters;

namespace Taleria.Converters;

public class EnumToStringPresentationConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        => (value is Enum enumValue) ? $"{System.Convert.ToInt32(enumValue)} {enumValue}" : "";
    

    // No need to implement converting back on a one-way binding 
    public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}