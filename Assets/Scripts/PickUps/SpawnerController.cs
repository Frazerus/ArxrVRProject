using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace PickUps
{
    public class SpawnerController : MonoBehaviour
    {
        public float forceAppliedToNewlySpawnedBodies;
        private IReadOnlyCollection<PickUpAbleSpawner> _spawners;
        public GameObject[] allItemTypes;

        public float SpanwnNewItemEverySeconds = 5;

        public static SpawnerController current;
        
        private int _spawnerAmount;
        private double _spawnPercentage;
        void Awake()
        {
            _spawners = FindObjectsOfType<PickUpAbleSpawner>();
            GameEventSystem.current.OnDropItem += NewItemInRandomLocation;
            
            _spawnerAmount = _spawners.Count;

            _spawnPercentage = 1d / _spawnerAmount;

            current = this;

            InvokeRepeating("NewItemInRandomLocation", 0, SpanwnNewItemEverySeconds);

        }

        private void NewItemInRandomLocation()
        {
            NewItemInRandomLocation(0);
        }

        private void NewItemInRandomLocation(int value)
        {
            foreach (var spawner in _spawners)
            {
                if (Random.Range(0f, 1f) < _spawnPercentage)
                {
                    var item = spawner.SpawnItem(); 
                    if (item != null)
                    {
                        MoveSpawnedItem(item);
                    }
                }
            }
        }

        private void MoveSpawnedItem(BasicPickUpAble item)
        {
            var itemBody = item.GetComponent<Rigidbody>();
            if (itemBody == null)
            {
                return;
            }

            var xForce = Random.Range(0f, forceAppliedToNewlySpawnedBodies);
            var zForce = Random.Range(0f, forceAppliedToNewlySpawnedBodies);
            var forceVector = new Vector3(xForce, 0, zForce);
            itemBody.AddForce(forceVector);

        }
    }
}
