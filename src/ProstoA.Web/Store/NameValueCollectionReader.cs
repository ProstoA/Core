using System.Collections.Generic;

namespace ProstoA.Web.Store {

    public class NameValueCollectionReader : IStoreReader<NameValueCollection> {
        private readonly IDictionary<string, string> _fieldMap;

        public NameValueCollectionReader(IDictionary<string, string> fieldMap) {
            _fieldMap = fieldMap;
        }

        public object GetValue(NameValueCollection store, string name) {
            var key = _fieldMap.ContainsKey(name) ? _fieldMap[name] : name;

            return store[key];
        }
    }
}