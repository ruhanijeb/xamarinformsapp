﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveUIDemo.Helper
{
    internal class KeyComparer<TObject, TKey> : IEqualityComparer<KeyValuePair<TKey, TObject>>
    {
        public bool Equals(KeyValuePair<TKey, TObject> x, KeyValuePair<TKey, TObject> y)
        {
            return x.Key.Equals(y.Key);
        }

        public int GetHashCode(KeyValuePair<TKey, TObject> obj)
        {
            return obj.Key.GetHashCode();
        }
    }
}
