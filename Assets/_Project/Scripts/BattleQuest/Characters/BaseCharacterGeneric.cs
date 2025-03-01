using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BattleQuest;
using ObjectPool;
using Scriptable_Objects;
using TMPro;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters
{
    public abstract class BaseCharacterGeneric<T> : BaseCharacter where T : BaseCharacterData
    {
        
        protected string EffectName;
        protected int CurrentDamage;
        protected bool EffectCharacter;
        protected GameObject Enemy;
        protected InteractionData EnemyInteractionData;
        protected Vector3 PositionTextEffect = new(0f, 0.6f, -0.7f);

        private int _maxHealth;
        private float _rangeTimeAttack;
        private InteractionData _thisInteractionData;
        private List<GameObject> _enemyList;
        private PoolMono<TextDamage> _pool;
        
        [SerializeField] protected T Data;
        protected GameManager _gameManager;
        [SerializeField] private TMP_Text _nameCharacterTMP;
        
        private void Awake()
        {
            //Исправить
            _gameManager = FindObjectOfType<GameManager>();

            _thisInteractionData = gameObject.GetComponent<InteractionData>();
            
            _thisInteractionData.NameCharacter = Data.CharacterName;
            _thisInteractionData.MaxHealth = Data.Health;

            _nameCharacterTMP.text = Data.CharacterName;
            
            Debug.Log("Awake()");
        }

        // public void Construct(GameManager gameManager)
        // {
        //     Debug.Log("Construct()");
        //     _gameManager = gameManager;
        // }

        protected void Start()
        {
            Debug.Log("Start()");

            
            Enemy = EnemyDetection();
            Debug.Log(Enemy == null? "Enemy is null" : "Enemy is not null");

            _rangeTimeAttack = Data.SpeedAttack;

            StartCoroutine(AttackCoroutine(Enemy, _rangeTimeAttack));
        }

        protected void Update()
        {
            CurrentDamage = RangeDamage(Data.DamageMin, Data.DamageMax);
        }

        private IEnumerator AttackCoroutine(GameObject enemy, float speedAttack)
        {
            while (true)
            {
                if (enemy == null) break;
                if (!_thisInteractionData) break;

                if (_thisInteractionData.StunEffect == false && _thisInteractionData.DebuffEffect == false)
                {
                    Attack(enemy, CurrentDamage);
                }


                if (_thisInteractionData.DebuffEffect)
                {
                    int damageDebuff = CurrentDamage * _thisInteractionData.DebuffPercent / 100;
                    Attack(enemy, damageDebuff);
                }

                yield return new WaitForSeconds(speedAttack);
            }
        }

        protected void Attack(GameObject enemy, int damage)
        {
            if (enemy) enemy.GetComponent<InteractionData>().GetDamage(damage);
            if (EffectCharacter == false) ApplyEffect();
        }
        
        

        protected virtual void ApplyEffect()
        {
            
        }

        private GameObject EnemyDetection()
        {
            
            //TODO: Переделать функцию
            GameObject[] findEnemies = GameObject.FindGameObjectsWithTag("Character");
            _enemyList = new List<GameObject>(findEnemies);
            _gameManager.EnemiesList = _enemyList
                .Union(findEnemies)
                .ToList();

            _enemyList.Remove(gameObject);

            if (_enemyList.Count == 0)
            {
                return null;
            }

            return _enemyList[0];
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
    }
}