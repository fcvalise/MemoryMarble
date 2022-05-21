using System.Collections.Generic;
using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class MemoryFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _memorySpherePrefab = null;
        [SerializeField] private SpawnPosition _spawnPosition = null;

        private Dictionary<string, MemorySphere> _memoryDictionary = new Dictionary<string, MemorySphere>();
        private GameObject _memorySphereContainer = null;
        private int _count = 0;
        public delegate void OnSpawnDelegate(GameObject go);
        public static OnSpawnDelegate spawnDelegate;
        public delegate void OnResetDelegate(GameObject go);
        public static OnResetDelegate resetDelegate;

        private void Awake()
        {
            _memorySphereContainer = new GameObject("MemorySphereContainer");
        }

        public void SpawnMemory(string name, Vector3 position)
        {
            if (!_memoryDictionary.ContainsKey(name))
            {
                var memorySphereInstance = Instantiate(_memorySpherePrefab, position, Quaternion.identity, _memorySphereContainer.transform);
                var memorySphere = memorySphereInstance.GetComponent<MemorySphere>();
                memorySphereInstance.name = name;
                _memoryDictionary.Add(name, memorySphere);
                _count++;
                spawnDelegate?.Invoke(memorySphereInstance);
            }
        }

        public void SpawnMemory(string name)
        {
            var position = _spawnPosition.GetRandomPosition();
            SpawnMemory(name, position);
        }

        public void SpawnMemory()
        {
            var name = "MemorySphere_" + _count;
            var position = _spawnPosition.GetRandomPosition();
            SpawnMemory(name, position);
        }

        public void ResetMemory(string name)
        {
            if (_memoryDictionary.ContainsKey(name))
            {
                _memoryDictionary[name].ResetLife();
                resetDelegate?.Invoke(_memoryDictionary[name].gameObject);
            }
        }
    }
}
