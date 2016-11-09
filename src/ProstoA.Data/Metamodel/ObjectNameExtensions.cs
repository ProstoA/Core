using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProstoA.Data.Metamodel {
    public static class ObjectNameExtensions {
        public static IObjectDisplay ExtractDisplayForEnum<T>(this T item) where T : struct, IConvertible {
            if (!typeof(T).GetTypeInfo().IsEnum) {
                throw new ArgumentException("T must be an enumerated type");
            }

            var name = item.ToString();
            var displayAttribute = typeof (T).GetField(name).GetCustomAttribute<DisplayAttribute>();

            return new ObjectDisplay(displayAttribute.Name, displayAttribute.Description);
        }

        public static IObjectIdentity ExtractIdentityForEnum<T>(this T item) where T : struct, IConvertible {
            if(!typeof(T).GetTypeInfo().IsEnum) {
                throw new ArgumentException("T must be an enumerated type");
            }

            var name = item.ToString();

            return new SimpleObjectIdentity(name);
        }
    }
}