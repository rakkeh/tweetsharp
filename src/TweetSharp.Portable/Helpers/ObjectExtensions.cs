using System;
using System.Linq;

namespace TweetSharp
{
    internal static class ObjectExtensions
    {
        public static bool EqualsAny(this object instance, params object[] args)
        {
            return args.Aggregate(false, (current, arg) => current | instance.Equals(arg));
        }

        public static bool Implements(this object instance, Type interfaceType)
        {
            return interfaceType.IsGenericTypeDefinition
                       ? instance.ImplementsGeneric(interfaceType)
                       : interfaceType.IsInstanceOfType(instance);
        }

        public static bool Implements<T>(this object instance)
        {
            var type = instance.GetType();
            var interfaceType = typeof (T);
            return interfaceType.IsGenericTypeDefinition
                       ? instance.ImplementsGeneric(interfaceType)
                       : interfaceType.IsAssignableFrom(type);
        }

        private static bool ImplementsGeneric(this Type type, Type targetType)
        {
            var interfaceTypes = type.GetInterfaces();
            foreach (var interfaceType in interfaceTypes)
            {
                if (!interfaceType.IsGenericType)
                {
                    continue;
                }

                if (interfaceType.GetGenericTypeDefinition() == targetType)
                {
                    return true;
                }
            }

            var baseType = type.BaseType;
            if (baseType == null)
            {
                return false;
            }

            return baseType.IsGenericType
                       ? baseType.GetGenericTypeDefinition() == targetType
                       : baseType.ImplementsGeneric(targetType);
        }

        private static bool ImplementsGeneric(this object instance, Type targetType)
        {
            return instance.GetType().ImplementsGeneric(targetType);
        }
    }
}