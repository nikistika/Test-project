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
    public abstract class BaseCharacter<T> : MonoBehaviour where T : BaseCharacterData
    {
        [SerializeField] internal T Data;
        [SerializeField] private TMP_Text _nameCharacterTMP;

        internal string EffectName;
        internal int CurrentDamage;
        internal bool EffectCharacter;
        internal GameObject Enemy;
        internal Vector3 PositionTextEffect = new(0f, 0.6f, -0.7f);

        private int _maxHealth;
        private float _rangeTimeAttack;
        private GameManager _gameManager;
        private InteractionData _thisInteractionData;
        private List<GameObject> _enemyList;
        private PoolMono<TextDamage> _pool;

        internal void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();

            _thisInteractionData = gameObject.GetComponent<InteractionData>();


            _thisInteractionData.NameCharacter = Data.CharacterName;
            _thisInteractionData.MaxHealth = Data.Health;

            _nameCharacterTMP.text = Data.CharacterName;
        }

        internal void Start()
        {
            Enemy = EnemyDetection();
            _rangeTimeAttack = Data.SpeedAttack;

            StartCoroutine(AttackCoroutine(Enemy, _rangeTimeAttack));
        }

        internal void Update()
        {
            CurrentDamage = RangeDamage(Data.DamageMin, Data.DamageMax);
        }

        private IEnumerator AttackCoroutine(GameObject enemy, float speedAttack)
        {
            while (enemy != null)
            {
                if (enemy == null) yield break;
                if (!_thisInteractionData) yield break;

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

        internal virtual void Attack(GameObject enemy, int damage)
        {
            enemy?.GetComponent<InteractionData>().GetDamage(damage);
        }

        private GameObject EnemyDetection()
        {
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

        private int RangeDamage(int minDamage, int maxDamage)
        {
            return Random.Range(minDamage, maxDamage);
        }
    }
}