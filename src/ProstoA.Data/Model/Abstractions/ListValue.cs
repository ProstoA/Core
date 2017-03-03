using System.Collections.Generic;

namespace ProstoA.Data.Model.Abstractions {
    public class ListValue : CollectionBaseValue<IValue> {
        public ListValue(IEnumerable<IValue> values) : base(values) { }

        protected override IValueItem MakeValueItem(IValue value, int index) {
            return new CompositeValueIndexer(index, value, this);
        }
    }
}