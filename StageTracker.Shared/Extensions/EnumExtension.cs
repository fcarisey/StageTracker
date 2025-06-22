using System.ComponentModel;
using System.Reflection;

namespace StageTracker.Shared.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        if (field == null) return value.ToString();

        var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;

        return attribute?.Description ?? value.ToString();
    }

    public static IEnumerable<T?> GetList<T>(this T value) where T : notnull, Enum
    {
        var fields = value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);

        return [.. fields.Select(field => (T)field.GetValue(null))];
    }
}
