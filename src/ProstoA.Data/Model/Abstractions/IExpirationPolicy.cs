using System;

namespace ProstoA.Data.Model.Abstractions {
    public interface IExpirationPolicy {
        bool Check(DateTimeOffset upToDate, DateTimeOffset checkDate);
    }
}