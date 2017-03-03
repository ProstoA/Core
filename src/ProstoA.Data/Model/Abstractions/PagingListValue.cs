using System;
using System.Collections.Generic;
using System.Linq;

namespace ProstoA.Data.Model.Abstractions {
    public class PagingListValue : CollectionBaseValue<IEnumerable<IValue>> {
        public PagingListValue(Func<int, IEnumerable<IValue>> reader) : base(Prepare(reader)) { }

        protected override IValueItem MakeValueItem(IEnumerable<IValue> items, int index) {
            return new CompositeValueIndexer(index, new ListValue(items), this);
        }

        private static IEnumerable<IEnumerable<IValue>> Prepare(Func<int, IEnumerable<IValue>> reader) {
            var pageNumber = 1;
            var values = reader(pageNumber++);

            while (values.Any()) {
                yield return values;
                values = reader(pageNumber++);
            }
        }
    }

    //public class PagingListValue : CollectionBaseValue<IEnumerable<IValue>> {
    //    public PagingListValue(IEnumerable<IValue> values, int pageSize) : base(Prepare(values, pageSize)) { }

    //    protected override IValueItem MakeValueItem(IEnumerable<IValue> items, int index) {
    //        return new CompositeValueIndexer(index, new ListValue(items));
    //    }

    //    private static IEnumerable<IEnumerable<IValue>> Prepare(IEnumerable<IValue> values, int pageSize) {
    //        return values.Select((value, index) => new { value, index }).GroupBy(x => x.index / pageSize, x => x.value) ;
    //    }
    //}
}