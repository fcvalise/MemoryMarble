using TMPro;
using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class MemorySphereText : MonoBehaviour
    {
        [SerializeField] private MemorySphere _memorySphere;
        private TextMeshPro _textMeshPro;

        private void Start()
        {
            _textMeshPro = GetComponent<TextMeshPro>();
        }

        void Update()
        {
            _textMeshPro.text = _memorySphere.name;
        }
    }
}
