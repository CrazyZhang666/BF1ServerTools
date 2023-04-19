﻿namespace BF1ServerTools.Themes.Converters;

public class StringToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace((string)value))
            return Visibility.Collapsed;

        return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
