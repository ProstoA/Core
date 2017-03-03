using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

using ProstoA.Data.Model.Abstractions;

namespace ProstoA.Data.Metamodel {
    public static class DataObjectExtensions {
        public static IObjectValue ToDataObject(this object data) {
            if (data == null) { return new DataObject(); }

            var type = data.GetType();

            //Name = type.Name;
            //Title = type.GetTypeInfo().GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? Name;
            //Description = type.GetTypeInfo().GetCustomAttribute<DescriptionAttribute>()?.Description;

            var props = type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Public|BindingFlags.Instance);

            DataObject t = new DataObject(props.Select(x => ToDataObjectItem(x, data)));

            return t;
        }

        private static IObjectValueItem ToDataObjectItem(PropertyInfo prop, object data, IObjectValue parent = null) {
            if (prop == null) { throw new ArgumentNullException(nameof(prop)); }

            var value = prop.GetValue(data);

            //Parents = new[] { parent.Identity };

            //Readonly = !prop.CanWrite;

            //var dataType = prop.GetCustomAttribute<DataTypeAttribute>()
            //    ?? new DataTypeAttribute(DataType.Text);

            //DataType = dataType.DataType == DataType.Custom
            //    ? dataType.CustomDataType
            //    : dataType.DataType.ToString();

            //Default = prop.GetCustomAttribute<DefaultValueAttribute>()?.Value?.ToString();

            var display = prop.GetCustomAttribute<DisplayAttribute>();

            // todo необходимо добавить логику на каких типах остановиться
            return new CompositeValueField(prop.Name, value.ToDataObject(), parent) {
                Title = display?.Name ?? prop.Name,
                Description = display?.Description,
                Prompt = display?.Prompt
            };
        }

        //public static IObjectDisplay ExtractDisplayForEnum<T>(this T item) where T: struct, IConvertible {
        //    if (!typeof(T).GetTypeInfo().IsEnum) { throw new ArgumentException("T must be an enumerated type"); }

        //    var name = item.ToString();
        //    var displayAttribute = typeof(T).GetField(name).GetCustomAttribute<DisplayAttribute>();

        //    return new ObjectDisplay(displayAttribute.Name, displayAttribute.Description);
        //}

        //public static IObjectIdentity ExtractIdentityForEnum<T>(this T item) where T: struct, IConvertible {
        //    if (!typeof(T).GetTypeInfo().IsEnum) { throw new ArgumentException("T must be an enumerated type"); }

        //    var name = item.ToString();

        //    return new SimpleObjectIdentity(name);
        //}
    }
}