using System;

namespace ProstoA.Data.Model.Abstractions {
    public interface IExpiringValue : IDeferredValue {
        DateTimeOffset? UpToDate { get; }

        bool Expired { get; }

        IExpirationPolicy ExpirationPolicy { get; }
    }
}