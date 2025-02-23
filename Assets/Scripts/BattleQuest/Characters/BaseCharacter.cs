using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using ObjectPool;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class BaseCharacter<T> : MonoBehaviour where T : BaseCharacterData
{
    private int _maxHealth;
    private float _rangeTimeAttack;
    private GameManager _gameManager;
    private InteractionData _thisInteractionData;
    private List<GameObject> _enemyList;

    internal string effectName;
    internal int _currentDamage;
    internal bool _effectCharacter;
    internal GameObject Enemy;
    internal Vector3 positionTextEffect = new(0f, 0.6f, -0.7f);

    [SerializeField] private TMP_Text _nameCharacterTMP;
    [SerializeField] internal T data;

    private PoolMono<TextDamage> pool;

    internal void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();

        _thisInteractionData = gameObject.GetComponent<InteractionData>();


        _thisInteractionData.nameCharacter = data.CharacterName;
        _thisInteractionData.maxHealth = data.Health;

        _nameCharacterTMP.text = data.CharacterName;
    }

    internal void Start()
    {
        Enemy = EnemyDetection();
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
            if (enemy == null) yield break;
            if (_thisInteractionData == null) yield break; 
            
            if (_thisInteractionData.stunEffect == false && _thisInteractionData.debuffEffect == false)
            {
                Attack(enemy, _currentDamage);
            }


            if (_thisInteractionData.debuffEffect)
            {
                int damageDebuff = _currentDamage * _thisInteractionData.debuffPercent / 100;
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
        _gameManager.enemiesList = _enemyList
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