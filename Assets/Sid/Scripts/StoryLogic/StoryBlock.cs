using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sid.Scripts.StoryLogic
{
    public class StoryBlock : MonoBehaviour
    {
        [HideInInspector] public bool currentCard;
        [SerializeField] private float fadeSpeed = 1;

        private TextMeshProUGUI _textMeshProUGUI;
        private Color _currentColor;

        private bool _forcefulChange = false;

        private void Start()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            _currentColor = _textMeshProUGUI.color;
            _currentColor.a = 0;
        }

        private void Update()
        {
            _textMeshProUGUI.color = _currentColor;
            
            if (!_forcefulChange)
                _currentColor.a = Mathf.Lerp(_currentColor.a, currentCard ? 1 : 0, fadeSpeed * Time.deltaTime);
            else _forcefulChange = false;
        }
    }
}
