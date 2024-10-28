namespace BookStoreManagerService.Common.Extensions;

public static class IntegerExtensions
{
    public static string ToEnumName<TEnum>(this Enum value)
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<Enum>()
            .Where(value.HasFlag)
            .Cast<TEnum>()
            .Select(_ => _.ToString())
            .Join(", ");
    }
}
