using System.Collections.Generic;

namespace ProstoA.Data.Model.Abstractions {
    public interface IRequiredValue<T> { }

    public interface IOptionalValue<T> {
        bool HasValue { get; }
    }


    public interface IValue {
        bool HasValue { get; }
    }

    public interface IDisplayModel {
        string Title { get; }

        string Hint { get; }

        string Description { get; }
    }




    public interface ICompositeValue : IValue {
        IEnumerable<IValueItem> Items { get; }

        IValueContainer Container { get; }
    }

    public interface IValueContainer {

    }

    public interface IValueItem {
        IValue Value { get; }
    }

    public interface IReferenceValue : IValue { }
}