using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT.Common.Extensions
{
    public class ObservableDictionary<Key, Value> : IDictionary<Key, Value>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        #region private props
        const string CountString = "Count";
        const string IndexerName = "Item[]";
        const string KeysName = "Keys";
        const string ValuesName = "Values";

        IDictionary<Key, Value> _dictionary;
        protected IDictionary<Key, Value> Dictionary
        {
            get { return _dictionary; }
        }
        #endregion

        #region private methods
        void Insert(Key key, Value value)
        {
            if (key == null) throw new ArgumentNullException("The key is null.");

            Value item;
            bool exists = Dictionary.TryGetValue(key, out item);
            if (exists) throw new ArgumentException("The key has already been added.");
            else
            {
                if (Equals(item, value)) return;
                Dictionary[key] = value;


            }
        }
        #endregion

        #region ctors
        public ObservableDictionary()
        {
            _dictionary = new Dictionary<Key, Value>();
        }
        public ObservableDictionary(IDictionary<Key, Value> dictionary)
        {
            _dictionary = new Dictionary<Key, Value>(dictionary);
        }
        public ObservableDictionary(IEqualityComparer<Key> comparer)
        {
            _dictionary = new Dictionary<Key, Value>(comparer);
        }
        public ObservableDictionary(int capacity)
        {
            _dictionary = new Dictionary<Key, Value>(capacity);
        }
        public ObservableDictionary(IDictionary<Key, Value> dictionary, IEqualityComparer<Key> comparer)
        {
            _dictionary = new Dictionary<Key, Value>(dictionary, comparer);
        }
        public ObservableDictionary(int capacity, IEqualityComparer<Key> comparer)
        {
            _dictionary = new Dictionary<Key, Value>(capacity, comparer);
        }
        #endregion

        #region IDictionary
        public Value this[Key key]
        {
            get
            {
                return Dictionary[key];
            }
            set
            {
                Dictionary[key] = value;
                Insert(key, value);
            }
        }

        public ICollection<Key> Keys
        {
            get
            {
                return Dictionary.Keys;
            }
        }

        public ICollection<Value> Values
        {
            get
            {
                return Dictionary.Values;
            }
        }

        public void Add(KeyValuePair<Key, Value> item)
        {
            throw new NotImplementedException();
        }

        public void Add(Key key, Value value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Key, Value> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Key key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<Key, Value>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Key, Value>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Key, Value> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Key key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Key key, out Value value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ICollection<KeyValuePair> (implemented in IDictionary)
        public int Count
        {
            get
            {
                return Dictionary.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return Dictionary.IsReadOnly;
            }
        }
        #endregion

        #region INotify
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region OnChanged Overloads
        protected virtual RaisePropertyChanged(string )
        #endregion
    }
}
