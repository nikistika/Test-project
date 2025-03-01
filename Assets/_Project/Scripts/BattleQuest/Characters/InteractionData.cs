using System;
using System.Collections;
using ObjectPool;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace BattleQuest
{
    public class InteractionData : MonoBehaviour
    {
        private PoolMono<TextDamage> _pool;

        public int MaxHealth;
        public int HP;
        public string NameCharacter;

        [SerializeField] private int _poolCount = 10;
        [SerializeField] private bool _autoExpand = false;
        [SerializeField] private TextDamage _textPrefab;
        [SerializeField] private TMP_Text _hpCharacterTMP;
        [SerializeField] private Slider _hpSlider;

        private Vector3 _positionTextDamage = new(0.3f, 0.3f, -0.7f);
        private GameManager _gameManager;
        
        public bool StunEffect {get; private set;}
        public bool DebuffEffect {get; private set;}
        public int DebuffPercent {get; private set;}

        private void Awake()
        {
            _pool = new PoolMono<TextDamage>(_textPrefab, _poolCount, transform);
            _pool.autoExpand = _autoExpand;
            HP = MaxHealth;
            _hpSlider.maxValue = MaxHealth;
            _hpSlider.value = MaxHealth;
            _hpCharacterTMP.text = $"{HP}/{MaxHealth}";
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void GetDamage(int damage)
        {
            HP -= damage;
            _hpSlider.value = HP;
            _hpCharacterTMP.text = $"{HP}/{MaxHealth}";

            if (HP <= 0)
            {
                _gameManager.EnemiesList.Remove(gameObject);
                Destroy(gameObject);
                return;
            }

            string textDamage = $"-{damage}";
            CreateTextView(textDamage, _positionTextDamage);
        }
        
        public void CreateTextView(string text, Vector3 positionText)
        {
            var textDamage = _pool.GetFreeElement();
            textDamage.transform.localPosition = positionText;
            textDamage.EditTextDamage(text);
            StartCoroutine(ReturnToPoolAfterDelay(textDamage, 2f));
        }

        public void StateStunEffect(bool state)
        {
            StunEffect = state;
            
        }
        
        public void StateDebuffEffect(bool state)
        {
            DebuffEffect = state;
        }
        
        public void StateDebuffEffect(bool state, int debuffPercent)
        {
            DebuffEffect = state;
            DebuffPercent = debuffPercent;
        }

        private IEnumerator ReturnToPoolAfterDelay(TextDamage textDamage, float delay)
        {
            yield return new WaitForSeconds(delay);
            _pool.SetObject(textDamage);
        }
    }
}