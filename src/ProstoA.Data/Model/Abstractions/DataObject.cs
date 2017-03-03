using System;
using System.Collections.Generic;
using System.Linq;

using ProstoA.Data.Store;
using ProstoA.Data.Metamodel;

namespace ProstoA.Data.Model.Abstractions {
    public class DataObject : IObjectValue {
        private readonly Dictionary<string, CompositeValueField> _items;

        public DataObject(params IObjectValueItem[] items) : this((IEnumerable<IObjectValueItem>)items) {}

        public DataObject(IEnumerable<IObjectValueItem> items) {
            _items = items.ToDictionary(x => x.Name, x => new CompositeValueField(x.Name, x.Value, this));
        }

        public bool HasValue => _items.Any();

        public IEnumerable<IValueItem> Items => _items.Values;

        public IValueContainer Container {
            get { throw new NotImplementedException(); }
        }

        public IObjectValueItem this[string name] => _items[name];


        //public IDataObject this[string name] {
        //    get { return new StringDataObject((ISimpleDataModel)Model[name], _dataAccessor.GetValue(name)); }
        //    set { _dataMutator.SetValue(name, ((ISimpleDataObject)value).Value); }
        //}



        //private IDataAccessor _dataAccessor;
        //private IDataMutator _dataMutator;

        //public DataObject(object data) {
        //    _dataAccessor = new TypeDataAccessor(data);
        //    _dataMutator = new TypeDataAccessor(data);
        //    //_model = new DataModel(data.GetType());
        //}

        //public DataObject(Type type) {
        //    _dataAccessor = new TypeDataAccessor(type);
        //    _dataMutator = new TypeDataAccessor(type);
        //    //_model = new DataModel(type);
        //}

        //private Dictionary<string, string> _data {
        //    get { return _dataAccessor.ToDictionary(); }
        //    set { _dataAccessor = new DictionaryDataAccessor(value); }
        //}
    }
}