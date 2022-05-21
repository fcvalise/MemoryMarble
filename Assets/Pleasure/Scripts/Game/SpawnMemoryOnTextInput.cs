using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryMarbleAdditional
{
    public class SpawnMemoryOnTextInput : MonoBehaviour
    {
        [SerializeField] private MemoryFactory _memoryFactory;
        [SerializeField] private DictationEngine _dictationEngine;

        private void Start()
        {
            _dictationEngine.OnPhraseRecognized.AddListener(OnTextInput);
        }

        private void OnDestroy()
        {
            _dictationEngine.OnPhraseRecognized.RemoveListener(OnTextInput);
        }

        public void OnTextInput(string text)
        {
            var splittedText = text.Split(" ");
            foreach (var word in splittedText)
            {
                _memoryFactory.SpawnMemory(word);
                _memoryFactory.ResetMemory(word);
            }
        }
    }
}
