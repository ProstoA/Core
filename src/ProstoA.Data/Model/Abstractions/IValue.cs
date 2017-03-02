namespace ProstoA.Data.Model.Abstractions {
    public interface IRequiredValue<T> {

    }

    public interface IOptionalValue<T> {
        bool HasValue { get; }
    }


    public interface IValue {
        bool HasValue { get; }
    }

    public interface ICompositeValue {

    }
}