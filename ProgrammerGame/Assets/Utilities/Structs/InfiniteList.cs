using System;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Utilities.Structs
{
    [Serializable]
    public class InfiniteList<T>
    {
        [SerializeField] private List<T> _list = new List<T>();

        private int _index = 0;

        public T Current => _list[_index];

        public T GetNext()
        {
            IncreaseIndex();
            return Current;
        }

        private void IncreaseIndex()
        {
            _index++;
            _index %= _list.Count;
        }
    }
}