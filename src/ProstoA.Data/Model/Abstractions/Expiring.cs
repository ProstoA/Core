using System;
using System.Threading.Tasks;

namespace ProstoA.Data.Model.Abstractions {
    public sealed class Expiring<T> : IExpiringValue where T: IValue {
        private readonly Func<Task<T>> _accessor;

        private Deferred<T> _deferredValue;
        private DateTimeOffset? _upToDate;

        public Expiring(IExpirationPolicy expirationPolicy, Func<Task<T>> accessor, TimeSpan? delay = null/*Infinity*/) {
            if (expirationPolicy == null) {
                throw new ArgumentNullException(nameof(expirationPolicy));
            }

            ExpirationPolicy = expirationPolicy;
            _accessor = accessor;
            _deferredValue = GetDeferredValue(delay);
        }

        public bool HasValue => GetDeferredValue().HasValue;

        public T Value => GetDeferredValue().Value;

        public bool Promised => GetDeferredValue().Promised;

        public Task Promise => GetDeferredValue().Promise;

        public DateTimeOffset? UpToDate => _upToDate;

        public bool Expired => UpToDate.HasValue && ExpirationPolicy.Check(UpToDate.Value, DateTimeOffset.Now);

        public IExpirationPolicy ExpirationPolicy { get; }

        private Deferred<T> GetDeferredValue(TimeSpan? delay = null) {
            if (Expired) {
                _deferredValue = new Deferred<T>(() => WrapAccesor(), delay);
            }

            return _deferredValue = _deferredValue ?? new Deferred<T>(() => WrapAccesor(), delay);
        }

        private async Task<T> WrapAccesor() {
            var result = await _accessor();
            _upToDate = DateTimeOffset.Now;
            return result;
        }
    }
}