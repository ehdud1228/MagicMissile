using TMPro;
using UnityEngine;

namespace Impact
{
    public class FadeOutText : MonoBehaviour
    {
        private TextMeshPro _textMeshPro;
        private float _alpha = 1f;
        private float _originalAlpha;
        private float _originalSize;

        /// <summary>
        /// The amount of time to wait before starting to fade out. 0 = no delay.
        /// </summary>
        public float waitingTime = 0.2f;
        
        public bool isFadeOut = true;
        public float fadeSpeed = 0.5f;
        
        public bool isSizeChange = false;
        
        private void Start()
        {
            _textMeshPro = GetComponent<TextMeshPro>();
            _originalSize = _textMeshPro.fontSize;
        }
        
        private void Update()
        {
            if (isFadeOut)
            {
                if (waitingTime > 0)
                {
                    waitingTime -= Time.deltaTime;
                }
                else
                {
                    _alpha -= fadeSpeed * Time.deltaTime;
                    _textMeshPro.color = new Color(_textMeshPro.color.r, _textMeshPro.color.g, _textMeshPro.color.b, _alpha);
                    if (_alpha <= 0)
                    {
                        Destroy(transform.parent.gameObject);
                    }
                }
            }
            if (isSizeChange)
            {
                _textMeshPro.fontSize = _originalSize * _alpha;
            }
        }
    }
}