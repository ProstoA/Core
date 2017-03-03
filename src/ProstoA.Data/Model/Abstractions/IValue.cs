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

        string Prompt { get; }

        string Description { get; }
    }



    public interface ICompositeValue : IValue {
        IEnumerable<IValueItem> Items { get; }

        IValueContainer Container { get; }
    }

    public interface ICollectionValue : ICompositeValue {
        ICollectionValueItem this[int index] { get; }
    }

    public interface IObjectValue : ICompositeValue {
        IObjectValueItem this[string name] { get; }
    }

    public interface IValueContainer {

    }

    public interface IValueItem {
        ICompositeValue Parent { get; }

        IValue Value { get; }

        //todo ограничения для значения



        //string DataType { get; }

        //bool Readonly { get; }

        //string Default { get; }

        //string Prompt { get; }
    }

    public interface ICollectionValueItem : IValueItem {
        int Index { get; }
    }

    public interface IObjectValueItem : IValueItem {
        string Name { get; }
    }

    public interface IReferenceValue : IValue { }
}