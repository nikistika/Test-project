using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HP_Panel : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _hp;
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private TMP_Text _hpCharacterTMP;

        private void Awake()
        {
            _hp = _maxHealth;
            _hpSlider.maxValue = _maxHealth;
            EditHPPanel(_hp);
        }

        private void GetDamage(int damage)
        {
            if (_hp - damage < 0)
            {
                _hp = 0;
                EditHPPanel(_hp);
            }
            else if (_hp > 0)
            {
                _hp -= damage;
                EditHPPanel(_hp);
            }
        }

        public void Heal(int healCount)
        {
            if (_hp < _maxHealth)
            {
                _hp += healCount;
                EditHPPanel(_hp);
            }

            if (_hp >= _maxHealth)
            {
                _hp = _maxHealth;
                EditHPPanel(_hp);
            }
        }

        private void EditHPPanel(int hp)
        {
            _hpSlider.value = hp;
            _hpCharacterTMP.text = $"{hp}/{_maxHealth}";
        }

        public void Get25Damage() => GetDamage(25);
    }
}