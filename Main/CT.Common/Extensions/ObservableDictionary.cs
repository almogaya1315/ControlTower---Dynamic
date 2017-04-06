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
        void Insert(Key key, Value newValue)
        {
            if (key == null) throw new ArgumentNullException("The key is null.");

            if (Dictionary.Keys.Contains(key))
                throw new ArgumentException("The key already exists.");

            Value oldValue;
            if (Dictionary.TryGetValue(key, out oldValue))
            {
                if (Equals(oldValue, newValue)) return;
                Dictionary[key] = newValue;
                RaiseCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<Key, Value>(key, newValue),
                                                                              new KeyValuePair<Key, Value>(key, oldValue));
            }
            else
            {
                Dictionary[key] = newValue;
                RaiseCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<Key, Value>(key, newValue));
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

        public void Add(Key key, Value value)
        {
            Insert(key, value);
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
        #endregion

        #region IEnumerator
        public IEnumerator<KeyValuePair<Key, Value>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ICollection<KeyValuePair> (implemented in IDictionary)
        public void Add(KeyValuePair<Key, Value> item)
        {
            Insert(item.Key, item.Value);
        }
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

        #region RaiseChanged Overloads
        void RaisePropertyChanged()
        {
            RaisePropertyChanged(CountString);
            RaisePropertyChanged(IndexerName);
            RaisePropertyChanged(KeysName);
            RaisePropertyChanged(ValuesName);
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void RaiseCollectionChanged()
        {
            RaisePropertyChanged();
            CollectionChanged?.Invoke(this, 
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        void RaiseCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<Key, Value> changedItem)
        {
            RaisePropertyChanged();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem));
        }
        void RaiseCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<Key, Value> newItem, 
                                                                          KeyValuePair<Key, Value> oldItem)
        {
            RaisePropertyChanged();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
        }
        void RaiseCollectionChanged(NotifyCollectionChangedAction action, ICollection<KeyValuePair<Key, Value>> newItems)
        {
            RaisePropertyChanged();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems));
        }
        #endregion
    }
}
