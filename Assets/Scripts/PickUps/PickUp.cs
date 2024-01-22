using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PickUps
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private int maximumNrOfItems = 5;
        public bool CanPickup { get; set; }
        [SerializeField]
        private List<PickUpEnum> currentItems;
        private int ItemCount = 0;

        private EventSystem _eventSystem;
        void Start()
        {
            currentItems = new List<PickUpEnum>();
            GameEventSystem.current.OnPickUp += PickUpItem;
            GameEventSystem.current.OnTryDropItem += DeliverItem;
        }

        private void PickUpItem(GameObject obj)
        {
            if (!CanPickup)
            {
                return;
            }
            var item = obj.GetComponent<BasicPickUpAble>();
            if (ItemCount < maximumNrOfItems)
            {
                obj.GetComponentInParent<PickUpAbleSpawner>().RemoveItemOfType(item.type);
                Destroy(obj);
                currentItems.Add(item.type);
                ItemCount++;
            }
        }

        private void DeliverItem(PickUpEnum type)
        {
            if (type == PickUpEnum.Any && currentItems.Count > 0)
            {
                ItemCount--;
                var removed = currentItems[0];
                currentItems.RemoveAt(0);
                GameEventSystem.current.DropItem(PickUpValueProvider.GetValue(removed));
                return;
            }
            foreach (var currType in currentItems)
            {
                if (type == currType)
                {
                    ItemCount--;
                    currentItems.Remove(currType);
                    GameEventSystem.current.DropItem(PickUpValueProvider.GetValue(currType));
                    return;
                }
            }
        }
    }
}
