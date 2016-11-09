using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProstoA.Common {
    public interface ISubset<out T> : IReadOnlyCollection<T> {
        int Offset { get; }

        int TotalCount { get; }
    }

    public class Subset<T> : ISubset<T> {
        private readonly IEnumerable<T> _items;

        public Subset(IEnumerable<T> items, int offset, int totalCount) {
            _items = items;
            Offset = offset;
            TotalCount = totalCount;
        }

        public int Count => _items.Count();

        public IEnumerator<T> GetEnumerator() {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int Offset { get; }

        public int TotalCount { get; }
    }
}