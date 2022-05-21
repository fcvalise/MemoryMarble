using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class LifeTimeColor : MonoBehaviour
    {
        [SerializeField] private MemorySphere _memorySphere;
        [SerializeField] private Gradient _colorGradient;
        [SerializeField] private AnimationCurve _evolutionCurve;
        [SerializeField] private float _maxEmissionIntensity = 5f;
        [SerializeField] private float _minEmissionIntensity = 1f;

        private Renderer _renderer = null;

        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _renderer.material = new Material(_renderer.material);
        }

        void Update()
        {
            float percent = _memorySphere.GetLifePercent();
            float evolutionValue = _evolutionCurve.Evaluate(percent);
            Color color = _colorGradient.Evaluate(evolutionValue);
            float emissionIntensity = Mathf.Lerp(_minEmissionIntensity, _maxEmissionIntensity, percent);

            _renderer.material.SetColor("_BaseColor", color);
            _renderer.material.SetColor("_EmissionColor", color * emissionIntensity);
        }
    }
}