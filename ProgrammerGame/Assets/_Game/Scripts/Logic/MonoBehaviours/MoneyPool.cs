using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Game.Logic.MonoBehaviours
{
    public class MoneyPool
    {
        public int Size => _items.Count;
        
        private readonly List<Money> _items = new List<Money>();

        public void Put(Money item)
        {
            item.transform
                .DOScale(Vector3.zero, .5f)
                .OnComplete(() =>
                {
                    item.gameObject.SetActive(false);
                });
            
            _items.Add(item);
        }

        public Money Get(Money prefab)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Value == prefab.Value)
                {
                    Money item = _items[i];
                    
                    _items.RemoveAt(i);

                    item.DOKill();
                    item.gameObject.SetActive(true);
                    item.transform.localScale = item.StartScale;
                    
                    return item;
                }
            }
            
            return Object.Instantiate(prefab);
        }
    }
}