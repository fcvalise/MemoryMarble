using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryMarble
{
    [RequireComponent(typeof(Rigidbody))]
    public class LifeTimeMass : MonoBehaviour
    {
        [SerializeField] private MemorySphere _memorySphere;
        [SerializeField] private AnimationCurve _massCurve;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float percent = _memorySphere.GetLifePercent();
            Vector3 force = Physics.gravity * _massCurve.Evaluate(percent);
            _rb.AddForce(force);
        }
    }
}
