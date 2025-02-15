using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using JetBrains.Annotations;
using ObjectPool;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class BaseCharacter<T> : MonoBehaviour where T : BaseCharacterData
{
    private int _maxHealth;
    internal int _currentDamage;
    private float _rangeTimeAttack;

    internal string effectName;
    
    internal bool _effectCharacter;
    internal GameObject Enemy;
    
    internal Vector3 positionTextEffect = new (0f, 0.6f, -0.7f);
    
    private InteractionData _thisInteractionData;

    [SerializeField] private TMP_Text _nameCharacterTMP;
    [SerializeField] internal T data;
    
    private PoolMono<TextDamage> pool;
    
    internal void Awake()
    {
        _thisInteractionData = gameObject.GetComponent<InteractionData>();

        _thisInteractionData.maxHealth = data.Health; 

        _nameCharacterTMP.text = data.CharacterName;
    }

    internal void Start()
    {
        Enemy = EnemyDetection();
        Debug.Log(Enemy == null ? "enemy is null" : "enemy is not null");
        _rangeTimeAttack = data.SpeedAttack;

        StartCoroutine(AttackCoroutine(Enemy, _rangeTimeAttack));
    }

    internal void Update()
    {
        _currentDamage = RangeDamage(data.DamageMin, data.DamageMax);
    }

    private IEnumerator AttackCoroutine(GameObject enemy, float speedAttack)
    {
        while (enemy != null)
        {   
            
            if (_thisInteractionData.stunEffect == false && _thisInteractionData.debuffEffect == false)
            {
                Attack(enemy, _currentDamage);
            }

            // if (_thisInteractionData.stunEffect)
            // {
            //     effectName = "Оглушение";
            //     gameObject.GetComponent<InteractionData>().CreateTextView(effectName, positionTextEffect);
            // }

            if (_thisInteractionData.debuffEffect)
            {
                // effectName = "Ослабление";
                // gameObject.GetComponent<InteractionData>().CreateTextView(effectName, positionTextEffect);
                int damageDebuff = _currentDamage * _thisInteractionData.debuffPercent/100;
                Debug.Log($"damageDebuff: {damageDebuff}");
                Attack(enemy, damageDebuff);
            }    
            yield return new WaitForSeconds(speedAttack);

        }
    }

    internal virtual void Attack(GameObject enemy, int damage)
    {
        enemy.GetComponent<InteractionData>().GetDamage(damage);
    }

    [CanBeNull]
    private GameObject EnemyDetection()
    {
        GameObject[] findEnemies = GameObject.FindGameObjectsWithTag("Character");
        List<GameObject> enemyList = new List<GameObject>(findEnemies);

        enemyList.Remove(gameObject);

        return enemyList[0];
    }

    private int RangeDamage(int minDamage, int maxDamage)
    {
        return Random.Range(minDamage, maxDamage);
    }
    
}