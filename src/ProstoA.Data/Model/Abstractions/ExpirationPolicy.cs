using System;

namespace ProstoA.Data.Model.Abstractions {
    public class ExpirationPolicy : IExpirationPolicy {
        private readonly TimeSpan _duration;
        public ExpirationPolicy(TimeSpan duration) {
            _duration = duration;
        }

        public bool Check(DateTimeOffset upToDate, DateTimeOffset checkDate) {
            return checkDate-upToDate > _duration;
        }
    }
}