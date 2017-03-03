using System;
using System.Collections.Generic;
using System.Linq;

namespace ProstoA.Data.Model.Abstractions {
    public abstract class CollectionBaseValue<T> : ICollectionValue {
        private readonly IEnumerable<T> _values;

        protected CollectionBaseValue(IEnumerable<T> values) {
            _values = values;
        }

        protected abstract IValueItem MakeValueItem(T item, int index);

        public bool HasValue => (_values?.Any()).GetValueOrDefault();

        public IEnumerable<IValueItem> Items => _values?.Select(MakeValueItem) ?? Enumerable.Empty<IValueItem>();


        public IValueContainer Container {
            get { throw new NotImplementedException(); }
        }

        public ICollectionValueItem this[int index] {
            get { throw new NotImplementedException(); }
        }
    }
}