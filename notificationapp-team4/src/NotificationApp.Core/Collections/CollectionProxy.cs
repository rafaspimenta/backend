using System;
using System.Collections;
using System.Collections.Generic;

namespace NotificationApp.Collections
{
    public class CollectionProxy<TSource, TProxy> : ICollection<TProxy> where TSource : TProxy
    {
        private readonly ICollection<TSource> reference;

        public CollectionProxy(ICollection<TSource> reference)
        {
            this.reference = reference ?? throw new ArgumentNullException(nameof(reference));
        }

        public int Count => this.reference.Count;

        public bool IsReadOnly => this.reference.IsReadOnly;

        public void Add(TProxy item)
        {
            this.reference.Add((TSource)item);
        }

        public void Clear()
        {
            this.reference.Clear();
        }

        public bool Contains(TProxy item) =>
            this.reference.Contains((TSource)item);

        public void CopyTo(TProxy[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TProxy> GetEnumerator()
        {
            foreach (var i in this.reference)
            {
                yield return i;
            }
        }

        public bool Remove(TProxy item) =>
            this.reference.Remove((TSource)item);

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var i in this.reference)
            {
                yield return i;
            }
        }
    }
}
