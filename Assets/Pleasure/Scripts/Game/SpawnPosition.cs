using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class SpawnPosition : MonoBehaviour
    {
        [SerializeField] private float _radius;

#if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
#endif

        public Vector3 GetRandomPosition()
        {
            return Random.insideUnitSphere * _radius + transform.position;
        }
    }
}