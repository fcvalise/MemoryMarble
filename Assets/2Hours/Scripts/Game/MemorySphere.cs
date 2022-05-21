using UnityEngine;

namespace MemoryMarble
{
    public class MemorySphere : MonoBehaviour
    {
        [SerializeField] private float _lifeTimeDuration = 30f;
        private float _lifeTime = 0;

        private void Start()
        {
            _lifeTime = _lifeTimeDuration;
        }

        private void Update()
        {
            _lifeTime = Mathf.Max(_lifeTime - Time.deltaTime, 0f);
        }

        public float GetLifePercent()
        {
            return _lifeTime / _lifeTimeDuration;
        }

        public void ResetLife()
        {
            _lifeTime = _lifeTimeDuration;
        }
    }
}