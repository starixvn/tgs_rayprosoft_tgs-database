using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

namespace TGS.Core.Infrastructures.Extensions;

public static class ObjectExtensions
{
    public static TAttribute GetPropertyAttribute<TObject, TAttribute>(this TObject obj, string propertyName)
        where TObject : class
        where TAttribute : Attribute
        => propertyName.IsNullOrEmpty()
            ? throw new ArgumentException($"PropertyName({propertyName}) can't not be null or empty")
            : (obj.GetType()?.GetProperty(propertyName)?.GetCustomAttribute<TAttribute>());

    public static string ToJson(this object obj, bool indented = false)
        => obj is null
            ? null
            : JsonSerializer.Serialize(
                obj,
                obj.GetType(),
                new JsonSerializerOptions { WriteIndented = indented });

    public static PropertyAccessor<T> WithPropertyExpression<T>(this T _, Expression<Func<T, object>> expr)
        => expr is not LambdaExpression _
            ? throw new ArgumentException("expr must be Lambda Expression.")
            : expr.Body is MemberExpression memberExpression
            && memberExpression.Member is PropertyInfo
            ? new PropertyAccessor<T>(expr)
            : throw new ArgumentException("Can't find property info.");
}
