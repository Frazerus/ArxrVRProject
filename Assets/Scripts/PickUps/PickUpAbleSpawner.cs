using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace PickUps
{
    public class PickUpAbleSpawner : MonoBehaviour
    {
        private List<BasicPickUpAble> _allPickUpAbles;
        public int maxNumberOfItems;
        
        public int initalDropAmount = 0;
        
        // Start is called before the first frame update
        void Start()
        {

            _allPickUpAbles = new List<BasicPickUpAble>();
            var childPickUp = GetComponentsInChildren<BasicPickUpAble>();
            foreach (var pickUp in childPickUp)
            {
                if (pickUp != null)
                {
                    _allPickUpAbles.Add(pickUp);
                }
            }


            while (initalDropAmount-- > 0)
                SpawnItem();
            
        }


        public void RemoveItemOfType(PickUpEnum type)
        {
            _allPickUpAbles.Remove(_allPickUpAbles.First(i => i.type == type));
        }

        [CanBeNull]
        public BasicPickUpAble SpawnItem()
        {
            if (_allPickUpAbles.Count == maxNumberOfItems)
            {
                return null;
            }

            var val = GetTypeNotExistentYet();
            var basicPickUpAbleObject = Instantiate(SpawnerController.current.allItemTypes[val], transform, true);

            var randomPosVec = new Vector3(
                Random.Range(-3, 3),
                Random.Range(-3, 3),
                Random.Range(-3, 3));

            var randomRotationVec = new Vector3(
                Random.Range(-90, 90),
                Random.Range(-90, 90),
                Random.Range(-90, 90));

            var randomRotation = new Quaternion();
            randomRotation.eulerAngles = randomRotationVec;

            basicPickUpAbleObject.transform.position = transform.position + randomPosVec;
            basicPickUpAbleObject.transform.rotation = randomRotation;

            var basicPickUpAble = basicPickUpAbleObject.GetComponent<BasicPickUpAble>();
            if (basicPickUpAble == null)
            {
                return null;
            }
            _allPickUpAbles.Add(basicPickUpAble);
            return basicPickUpAble;
        }

        private int GetTypeNotExistentYet()
        {
            var type = PickUpValueProvider.GetRandomPickUpEnum();
            return type;
        }
    }
}
