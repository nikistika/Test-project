using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using Scriptable_Objects;
using TMPro;
using Chatacter;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Characters
{
    public abstract class BaseCharacterGeneric<T> : BaseCharacter where T : BaseCharacterData
    {
        protected string EffectName;
        protected int CurrentDamage;
        protected bool EffectCharacter;
        protected Vector3 PositionTextEffect = new(0f, 0.6f, -0.7f);

        private int _maxHealth;
        private float _rangeTimeAttack;
        private List<GameObject> _enemyList;
        private PoolMono<TextDamage> _pool;
        private Vector3 _positionTextDamage = new(0.3f, 0.3f, -0.7f);

        [SerializeField] protected T Data;
        [SerializeField] private int HP;
        [SerializeField] private bool _autoExpand = false;
        [SerializeField] private int _poolCount = 10;
        [SerializeField] private TextDamage _textPrefab;
        [SerializeField] private TMP_Text _nameCharacterTMP;
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private TMP_Text _hpCharacterTMP;

        public bool StunEffect { get; private set; }
        public bool DebuffEffect { get; private set; }
        public int DebuffPercent { get; private set; }

        private void Awake()
        {
            _maxHealth = Data.Health;

            CharacterName = Data.CharacterName;

            HP = _maxHealth;
            _hpSlider.maxValue = _maxHealth;
            _hpSlider.value = _maxHealth;
            _hpCharacterTMP.text = $"{HP}/{_maxHealth}";

            _pool = new PoolMono<TextDamage>(_textPrefab, _poolCount, transform);
            _pool.autoExpand = _autoExpand;

            _nameCharacterTMP.text = Data.CharacterName;
        }

        public override void StateStunEffect(bool state)
        {
            StunEffect = state;
        }

        public override void StateDebuffEffect(bool state)
        {
            DebuffEffect = state;
        }

        public override void StateDebuffEffect(bool state, int debuffPercent)
        {
            DebuffEffect = state;
            DebuffPercent = debuffPercent;
        }

        public override void GetDamage(int damage)
        {
            HP -= damage;
            _hpSlider.value = HP;
            _hpCharacterTMP.text = $"{HP}/{_maxHealth}";

            if (HP <= 0)
            {
                Destroy(gameObject);

                return;
            }

            string textDamage = $"-{damage}";
            CreateTextView(textDamage, _positionTextDamage);
        }

        public override void CreateTextView(string text, Vector3 positionText)
        {
            var textDamage = _pool.GetFreeElement();
            textDamage.transform.localPosition = positionText;
            textDamage.EditTextDamage(text);
            StartCoroutine(ReturnToPoolAfterDelay(textDamage, 2f));
        }

        protected void Start()
        {
            _rangeTimeAttack = Data.SpeedAttack;

            StartCoroutine(AttackCoroutine(Enemy, _rangeTimeAttack));
        }

        protected void Update()
        {
            CurrentDamage = RangeDamage(Data.DamageMin, Data.DamageMax);
        }

        private IEnumerator AttackCoroutine(BaseCharacter enemy, float speedAttack)
        {
            while (true)
            {
                if (enemy == null)
                {
                    VictoryPanel.ShowVictoryText(Data.CharacterName);
                    VictoryPanel.gameObject.SetActive(true);
                    break;
                }

                if (StunEffect == false && DebuffEffect == false)
                {
                    Attack(enemy, CurrentDamage);
                }


                if (DebuffEffect)
                {
                    int damageDebuff = CurrentDamage * DebuffPercent / 100;
                    Attack(enemy, damageDebuff);
                }

                yield return new WaitForSeconds(speedAttack);
            }
        }

        protected void Attack(BaseCharacter enemy, int damage)
        {
            if (enemy) enemy.GetDamage(damage);
            if (EffectCharacter == false) ApplyEffect();
        }


        protected virtual void ApplyEffect()
        {
        }

        protected bool TryApplyEffect(float effectChance)
        {
            if (Random.value < effectChance)
            {
                EffectCharacter = true;
                return true;
            }

            return false;
        }

        private int RangeDamage(int minDamage, int maxDamage)
        {
            return Random.Range(minDamage, maxDamage);
        }

        private IEnumerator ReturnToPoolAfterDelay(TextDamage textDamage, float delay)
        {
            yield return new WaitForSeconds(delay);
            _pool.SetObject(textDamage);
        }
    }
}