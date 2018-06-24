﻿using System;
using System.Collections;
using System.Reflection;

namespace System.Windows.Forms.Layout
{    
    public class ArrangedElementCollection : IList, ICollection, IEnumerable
    {
        private ArrayList _innerList;
        internal static ArrangedElementCollection Empty = new ArrangedElementCollection(0);

        internal ArrangedElementCollection()
        {
            this._innerList = new ArrayList(4);
        }

        internal ArrangedElementCollection(ArrayList innerList)
        {
            this._innerList = innerList;
        }

        private ArrangedElementCollection(int size)
        {
            this._innerList = new ArrayList(size);
        }

        private static void Copy(ArrangedElementCollection sourceList, int sourceIndex, ArrangedElementCollection destinationList, int destinationIndex, int length)
        {
            if (sourceIndex < destinationIndex)
            {
                sourceIndex += length;
                destinationIndex += length;
                while (length > 0)
                {
                    destinationList.InnerList[--destinationIndex] = sourceList.InnerList[--sourceIndex];
                    length--;
                }
            }
            else
            {
                while (length > 0)
                {
                    destinationList.InnerList[destinationIndex++] = sourceList.InnerList[sourceIndex++];
                    length--;
                }
            }
        }

        public void CopyTo(Array array, int index)
        {
            this.InnerList.CopyTo(array, index);
        }

        public override bool Equals(object obj)
        {
            ArrangedElementCollection elements = obj as ArrangedElementCollection;
            if ((elements == null) || (this.Count != elements.Count))
            {
                return false;
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (this.InnerList[i] != elements.InnerList[i])
                {
                    return false;
                }
            }
            return true;
        }

        public virtual IEnumerator GetEnumerator() =>
            this.InnerList.GetEnumerator();

        public override int GetHashCode() =>
            base.GetHashCode();

        internal void MoveElement(IArrangedElement element, int fromIndex, int toIndex)
        {
            int length = toIndex - fromIndex;
            switch (length)
            {
                case -1:
                case 1:
                    this.InnerList[fromIndex] = this.InnerList[toIndex];
                    break;

                default:
                    {
                        int sourceIndex = 0;
                        int destinationIndex = 0;
                        if (length > 0)
                        {
                            sourceIndex = fromIndex + 1;
                            destinationIndex = fromIndex;
                        }
                        else
                        {
                            sourceIndex = toIndex;
                            destinationIndex = toIndex + 1;
                            length = -length;
                        }
                        Copy(this, sourceIndex, this, destinationIndex, length);
                        break;
                    }
            }
            this.InnerList[toIndex] = element;
        }

        int IList.Add(object value) =>
            this.InnerList.Add(value);

        void IList.Clear()
        {
            this.InnerList.Clear();
        }

        bool IList.Contains(object value) =>
            this.InnerList.Contains(value);

        int IList.IndexOf(object value) =>
            this.InnerList.IndexOf(value);

        void IList.Insert(int index, object value)
        {
            throw new NotSupportedException();
        }

        void IList.Remove(object value)
        {
            this.InnerList.Remove(value);
        }

        void IList.RemoveAt(int index)
        {
            this.InnerList.RemoveAt(index);
        }

        public virtual int Count =>
            this.InnerList.Count;

        internal ArrayList InnerList =>
            this._innerList;

        public virtual bool IsReadOnly =>
            this.InnerList.IsReadOnly;

        internal virtual IArrangedElement this[int index] =>
            ((IArrangedElement)this.InnerList[index]);

        bool ICollection.IsSynchronized =>
            this.InnerList.IsSynchronized;

        object ICollection.SyncRoot =>
            this.InnerList.SyncRoot;

        bool IList.IsFixedSize =>
            this.InnerList.IsFixedSize;

        object IList.this[int index]
        {
            get =>
                this.InnerList[index];
            set
            {
                throw new NotSupportedException();
            }
        }
    }
}
