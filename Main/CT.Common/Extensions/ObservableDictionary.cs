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
        #region IDictionary
        public Value this[Key key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Key> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Value> Values
        {
            get
            {
                throw new NotImplementedException();
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

        #region INotify
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
