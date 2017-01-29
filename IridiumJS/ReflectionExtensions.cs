#if NETSTANDARD1_3
using System;
using System.Linq;
using System.Reflection;

namespace IridiumJS
{
    internal static class ReflectionExtensions
    {
        internal static bool IsEnum(this Type type)
        {
            return type.GetTypeInfo().IsEnum;
        }

        internal static bool IsGenericType(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        internal static bool IsValueType(this Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }

        internal static bool HasAttribute<T>(this ParameterInfo member) where T : Attribute
        {
            return member.GetCustomAttributes<T>().Any();
        }
    }
}
#else
using System;
using System.Reflection;

namespace IridiumJS
{
    internal static class ReflectionExtensions
    {
        internal static bool IsEnum(this Type type)
        {
#if NETSTANDARD
            return type.IsEnum();
#else
            return type.IsEnum;
#endif
        }

        internal static bool IsGenericType(this Type type)
        {
#if NETSTANDARD
            return type.IsGenericType();
#else
            return type.IsGenericType;
#endif
        }

        internal static bool IsValueType(this Type type)
        {
#if NETSTANDARD
            return type.IsValueType();
#else
            return type.IsValueType;
#endif
        }

        internal static bool HasAttribute<T>(this ParameterInfo member) where T : Attribute
        {
#if NETSTANDARD
            return member.HasAttribute<T>();
#else
            return Attribute.IsDefined(member, typeof(T));
#endif
        }

        internal static MethodInfo GetMethodInfo(this Delegate d)
        {
#if NETSTANDARD
            return d.GetMethodInfo();
#else
            return d.Method;
#endif
        }
    }
}
#endif
