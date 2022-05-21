using System.Collections;
using System.Collections.Generic;
using FIMSpace.FLook;

using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class SnailAnimator : MonoBehaviour
    {
        private Animator _animator;
        private List<FLookAnimator> _lookAnimatorList = new List<FLookAnimator>();

        private void Start()
        {
            _animator = GetComponent<Animator>();
            MemoryFactory.spawnDelegate += OnSpawnMemory;
            _lookAnimatorList = new List<FLookAnimator>(GameObject.FindObjectsOfType<FLookAnimator>());
        }

        private void OnSpawnMemory(GameObject go)
        {
            _animator.SetTrigger("SpawnMemory");
            foreach (var lookAnimator in _lookAnimatorList)
            {
                lookAnimator.SetMomentLookTarget(go.transform, null, 5, true);
            }
        }
    }
}
