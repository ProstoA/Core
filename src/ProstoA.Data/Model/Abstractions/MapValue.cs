using System.Collections.Generic;

namespace ProstoA.Data.Model.Abstractions {
    public class MapValue : CollectionBaseValue<KeyValuePair<string, IValue>> {
        public MapValue(IDictionary<string, IValue> values) : base(values) { }

        protected override IValueItem MakeValueItem(KeyValuePair<string, IValue> item, int index) {
            return new CompositeValueField(item.Key, item.Value);
        }
    }
}