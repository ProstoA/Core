using System;

namespace ProstoA.Data.Model.Abstractions {
    public sealed class CompositeValueIndexer : ICollectionValueItem {
        public CompositeValueIndexer(int index, IValue value, ICompositeValue parent) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            if (parent == null) {
                throw new ArgumentNullException(nameof(parent));
            }

            Index = index;
            Value = value;
            Parent = parent;
        }

        public int Index { get; }

        public IValue Value { get; }

        public override string ToString() {
            return $"[{Index}]";
        }

        public ICompositeValue Parent { get; }
    }
}