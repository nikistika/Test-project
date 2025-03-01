using TMPro;
using UnityEngine;

namespace UI
{
    public class TextDamage : MonoBehaviour
    {
        [SerializeField] private float _speedTranslate = 0.6f;

        private void Update()
        {
            transform.Translate(0, _speedTranslate * Time.deltaTime, 0);
        }

        public void EditTextDamage(string text)
        {
            gameObject.GetComponent<TextMeshPro>().text = text;
        }
    }
}