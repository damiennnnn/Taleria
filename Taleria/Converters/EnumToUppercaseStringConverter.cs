using Avalonia.Data.Converters;

namespace Taleria.Converters;

public class EnumToUppercaseStringConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        => (value is Enum enumValue) ? enumValue.ToString().ToUpper() : value;
    

    // No need to implement converting back on a one-way binding 
    public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}