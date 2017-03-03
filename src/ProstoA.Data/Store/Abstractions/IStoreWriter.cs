using ProstoA.Data.Model.Abstractions;

namespace ProstoA.Data.Store {
    public interface IStoreWriter<in TStore> {
        void GetValue(TStore store, IValue value);
    }
}