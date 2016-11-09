using System.Collections.Generic;

namespace ProstoA.Common {
    public interface ILogger {
        void WriteLog(string text);

        IReadOnlyCollection<string> Log { get; }
    }
}