﻿namespace ProstoA.Data.Store.ModelBinding {
    public interface IValueProvider {
        bool ContainsPrefix(string prefix);
        IValueProviderResult GetValue(string key);
    }
}