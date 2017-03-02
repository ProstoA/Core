using System;
using System.Threading.Tasks;

namespace ProstoA.Data.Model.Abstractions {
    public sealed class Deferred<T> : IDeferredValue where T : IValue {
        private readonly Func<Task<T>> _accessor;

        private Task<T> _promise;

        public Deferred(Func<T> accessor, TimeSpan? delay = null/*Infinity*/)
            : this(() => Task.FromResult(accessor()), delay) { }

        public Deferred(Func<Task<T>> accessor, TimeSpan? delay = null/*Infinity*/) {
            _accessor = accessor;

            // Если загружать значение при первом обращении
            if (!delay.HasValue) {
                return;
            }

            // Если загружать значение сразу
            if (delay.Value == TimeSpan.Zero) {
                _promise = _accessor();
            }

            // Если зугружать значение с задержкой
            var task = DeleayStart(delay.Value);
        }

        public bool HasValue => Promised && _promise.IsCompleted;

        public T Value => GetValue();

        public bool Promised => _promise != null;

        public Task Promise => GetPromise();

        private T GetValue() {
            return GetPromise().Result;
        }

        private Task<T> GetPromise() {
            return _promise = _promise ?? _accessor();
        }

        private async Task DeleayStart(TimeSpan delay) {
            await Task.Delay(delay);
            var promise = GetPromise();
        }
    }
}