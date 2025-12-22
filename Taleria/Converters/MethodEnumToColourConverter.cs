using Avalonia.Data.Converters;

namespace Taleria.Converters;

public class MethodEnumToColourConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        => value switch
        {
            Method.Get => "#4CAF50",       // Green
            Method.Post => "#2196F3",      // Blue
            Method.Put => "#FFC107",       // Amber
            Method.Delete => "#F44336",    // Red
            Method.Patch => "#9C27B0",     // Purple
            Method.Head => "#33C2B0",      // Teal
            Method.Options => "#FF9800",   // Orange
            Method.Merge => "#EF5686",     // Pink
            Method.Copy => "#00BCD4",      // Cyan
            Method.Search => "#8BC34A",    // Light Green
            _ => "#000000"                 // Default to Black
        };
    

    // No need to implement converting back on a one-way binding 
    public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}