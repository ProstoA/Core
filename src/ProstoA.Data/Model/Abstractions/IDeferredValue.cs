using System.Threading.Tasks;

namespace ProstoA.Data.Model.Abstractions {
    public interface IDeferredValue : IValue {
        bool Promised { get; }

        Task Promise { get; }
    }
}