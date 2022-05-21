using System.Collections.Generic;
using UnityEngine;

namespace MemoryMarble
{
    public class MemoryFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _memorySpherePrefab = null;
        [SerializeField] private SpawnPosition _spawnPosition = null;

        private Dictionary<string, MemorySphere> _memoryDictionary = new Dictionary<string, MemorySphere>();
        private GameObject _memorySphereContainer = null;
        private int _count = 0;

        private void Awake()
        {
            _memorySphereContainer = new GameObject("MemorySphereContainer");
        }

        public void SpawnMemory(string name, Vector3 position)
        {
            var memorySphereInstance = Instantiate(_memorySpherePrefab, position, Quaternion.identity, _memorySphereContainer.transform);
            var memorySphere = memorySphereInstance.GetComponent<MemorySphere>();
            _memoryDictionary.Add(name, memorySphere);
            _count++;
        }

        public void SpawnMemory()
        {
            var name = "MemorySphere_" + _count;
            var position = _spawnPosition.GetRandomPosition();
            SpawnMemory(name, position);
        }
    }
}
