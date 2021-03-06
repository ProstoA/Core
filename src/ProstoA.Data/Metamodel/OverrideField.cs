using System.Collections.Generic;
using System.Reflection;

namespace ProstoA.Data.Metamodel {
    public class OverrideField : IDataModelFix {
        public OverrideField(string name, string title) {
            Name = name;
            Title = title;
        }

        public string Name { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<IDataModel> Applay(IEnumerable<IDataModel> items) {
            foreach (var item in items) {
                if (item.Identity.Key != Name) {
                    yield return item;
                    continue;
                }

                var fieldArgs = item.GetType().GenericTypeArguments;
                var fieldType = typeof (DataField<>).MakeGenericType(fieldArgs);

                var title = string.IsNullOrEmpty(Title) ? item.Display.Title : Title;
                var constraints = fieldType.GetTypeInfo().GetProperty("Constraints").GetValue(item);

                var fieldConstructor = fieldType.GetConstructor(new[] { typeof(string), typeof(string), typeof(DataConstraints) });
                var field = fieldConstructor.Invoke(new object[] { Name, title, constraints });

                if (!string.IsNullOrEmpty(Description)) {
                    fieldType.GetProperty("Description").SetValue(field, Description);
                }

                yield return (IDataModel) field;
            }
        }
    }
}