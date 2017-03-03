using System;

namespace ProstoA.Data.Model.Abstractions {
    public sealed class CompositeValueField : IValueItem, IDisplayModel {
        public CompositeValueField(string name, IValue value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            Name = name;
            Value = value;
        }

        public string Name { get; }

        public IValue Value { get; }

        public string Title { get; set; }

        public string Hint { get; set; }

        public string Description { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}