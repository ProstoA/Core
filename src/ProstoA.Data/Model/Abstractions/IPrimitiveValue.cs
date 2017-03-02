namespace ProstoA.Data.Model.Abstractions {
    public interface IPrimitiveValue<T> : IValue {

    }

    public struct ClassPrimitiveValue<T> : IPrimitiveValue<T> where T: class {
        private readonly T _value;

        public ClassPrimitiveValue(T value) {
            HasValue = value != null;
            _value = value;
        }

        public bool HasValue { get; }

        public override string ToString() {
            return HasValue ? _value.ToString() : string.Empty;
        }

        public static implicit operator ClassPrimitiveValue<T>(T value) {
            return new ClassPrimitiveValue<T>(value);
        }

        public static implicit operator T(ClassPrimitiveValue<T> value) {
            return value._value;
        }
    }

    public struct StructPrimitiveValue<T> : IPrimitiveValue<T> where T : struct {
        private readonly T _value;

        public StructPrimitiveValue(T value) {
            HasValue = true;
            _value = value;
        }

        public bool HasValue { get; }

        public override string ToString() {
            return HasValue ? _value.ToString() : string.Empty;
        }

        public static implicit operator StructPrimitiveValue<T>(T value) {
            return new StructPrimitiveValue<T>(value);
        }

        public static implicit operator T(StructPrimitiveValue<T> value) {
            return value._value;
        }

        public static implicit operator StructPrimitiveValue<T>(T? value) {
            return value.HasValue
                ? new StructPrimitiveValue<T>(value.Value)
                : new StructPrimitiveValue<T>();
        }

        public static implicit operator T? (StructPrimitiveValue<T> value) {
            return value.HasValue ? (T?)null : value._value;
        }
    }
}