using System;
using System.Linq.Expressions;

using ProstoA.Data.Metamodel;
using ProstoA.Data.Model.Abstractions;

namespace ProstoA.Operations.Queries {
    public class GetByKey<TKey, TModel> : IDataQuery<IObjectValue> {
        public Expression<Func<TModel, TKey>> KeySeelctor { get; set; }
        public TKey Key { get; set; }

        public GetByKey(Expression<Func<TModel, TKey>> keySeelctor, TKey key, params Expression<Func<TModel, object>>[] fields) {
            KeySeelctor = keySeelctor;
            Key = key;
            // ProjectionModel = new DataModel(typeof (TModel));
        }

        // public IDataModel ProjectionModel { get; }
    }
}