using System;

namespace ProstoA.Data.Model.Abstractions {
    public sealed class CompositeValueIndexer : IValueItem {
        private readonly int _index;

        public CompositeValueIndexer(int index, IValue value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            _index = index;
            Value = value;
        }

        public IValue Value { get; }

        public override string ToString() {
            return _index.ToString();
        }
    }
}