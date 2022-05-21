using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class LookAtCamera : MonoBehaviour
    {
        private Transform _cameraTransform;

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
        }

        void Update()
        {
            transform.LookAt(_cameraTransform.position);
        }
    }
}
