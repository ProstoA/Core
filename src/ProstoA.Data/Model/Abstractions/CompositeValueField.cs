using System;

namespace ProstoA.Data.Model.Abstractions {
    public sealed class CompositeValueField : IObjectValueItem, IDisplayModel {
        public CompositeValueField(string name, IValue value, ICompositeValue parent) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            if (parent == null) {
                throw new ArgumentNullException(nameof(parent));
            }

            Name = name;
            Value = value;
            Parent = parent;
        }

        public string Name { get; }

        public IValue Value { get; }

        public ICompositeValue Parent { get; }

        public string Title { get; set; }

        public string Prompt { get; set; }

        public string Description { get; set; }

        public override string ToString() {
            return $".{Name}";
        }
    }
}