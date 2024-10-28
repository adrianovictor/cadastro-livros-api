using System.Globalization;

namespace BookStoreManagerService.Common.Extensions;

public static class StringExtensions
{
    public static bool IsNotEmpty(this string str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }

    public static bool IsEmpty(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    public static T ToEnum<T>(this string value, string defaultValue = null) where T : struct
    {
        if (value.IsEmpty() && defaultValue.IsEmpty()) return default(T);

        T result;
        return !Enum.TryParse(value.GetValueOrDefault(defaultValue), true, out result) ? default(T) : result;
    }

    public static string GetValueOrDefault(this string str, string defaultValue)
    {
        return str.IsNotNullOrEmpty() ? str : defaultValue;
    }

    public static string GetValueOrDefault(this string str, Func<string> defaultValue)
    {
        return str.IsNotEmpty() ? str : defaultValue();
    }

    public static string ToEnumName<TEnum>(this string value)
    {
        return Enum.GetName(typeof(TEnum), value.ToInt());
    }

    public static int ToInt(this string value)
    {
        if (!int.TryParse(value, out var number))
        {
            number = 0;
        }

        return number;
    }

    public static long ToLong(this string value)
    {
        if (!long.TryParse(value, out var number))
        {
            number = 0;
        }

        return number;
    }

    public static bool ToBool(this string value)
    {
        if (!bool.TryParse(value, out var result))
        {
            result = false;
        }

        return result;
    }

    public static DateTime? ToDateTime(this string value, string format = "dd/MM/yyyy")
    {
        if (value.IsNullOrEmpty())
        {
            return null;
        }

        if (DateTime.TryParseExact(value.ToString().SafeTrim(), format, CultureInfo.CurrentUICulture.DateTimeFormat, DateTimeStyles.AssumeLocal, out var result))
        {
            return result;
        }

        return null;
    }

    public static DateTime? ToDate(this string value, string format = "dd/MM/yyyy")
    {
        var result = value.ToDateTime(format);
        if (result.HasValue)
        {
            return result.Value.Date;
        }
        return result;
    }

    public static TimeSpan ToTime(this string value)
    {
        return TimeSpan.Parse(value);
    }

    public static string Join(this IEnumerable<string> values, string separator = ",")
    {
        return string.Join(separator, values.Compact());
    }

    public static IEnumerable<T> Compact<T>(this IEnumerable<T> items)
    {
        return items.Where(_ => _.IsNotNull() && _.ToString().IsNotEmpty());
    }
}

