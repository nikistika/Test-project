using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using ObjectPool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public abstract class BaseCharactersMonoBehaviour<T> : MonoBehaviour where T : BaseCharacterScriptableObject
{
    private int _maxHealth;
    private int _currentDamage;
    private float _rangeTimeAttack;
    internal GameObject enemy;

    public int HP;

    [SerializeField] private TMP_Text _hpCharacterTMP;
    [SerializeField] private TMP_Text _nameCharacterTMP;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Canvas _canvas;
    [SerializeField] internal T data;

    [SerializeField] private int poolCount = 10;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private TextDamage textPrefab;

    private PoolMono<TextDamage> pool;

    void Awake()
    {
        _maxHealth = data.Health;
        _hpSlider.maxValue = _maxHealth;
        _hpSlider.value = _maxHealth;
        HP = _maxHealth;

        _hpCharacterTMP.text = $"{HP}/{_maxHealth}";
        _nameCharacterTMP.text = data.CharacterName;

        pool = new PoolMono<TextDamage>(textPrefab, poolCount, transform);
        pool.autoExpand = autoExpand;
    }

    private void Start()
    {
        enemy = EnemyDetection();
        Debug.Log(enemy == null ? "enemy is null" : "enemy is not null");
        _rangeTimeAttack = data.SpeedAttack;

        StartCoroutine(AttackCoroutine(enemy, _currentDamage, _rangeTimeAttack));
    }


    public void GetDamage(int damage)
    {
        HP -= damage;
        _hpSlider.value = HP;
        _hpCharacterTMP.text = $"{HP}/{_maxHealth}";
        Debug.Log($"Current health {data.CharacterName}: {HP}");
        if (HP <= 0) Destroy(gameObject);

        CreateTextDamage(damage);
    }

    internal void OnMouseDown()
    {
        GetDamage(25);
    }

    private IEnumerator AttackCoroutine(GameObject enemy, int currentDamage, float speedAttack)
    {
        while (enemy != null)
        {
            Attack(enemy);
            yield return new WaitForSeconds(speedAttack);
        }
    }

    internal virtual void Attack(GameObject enemy)
    {
        _currentDamage = RangeDamage(data.DamageMin, data.DamageMax);
        enemy.GetComponent<BaseCharactersMonoBehaviour<BaseCharacterScriptableObject>>().GetDamage(_currentDamage);
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

    private void CreateTextDamage(int damage)
    {
        Vector3 positionText = new Vector3(0.3f, 0.3f, -0.7f);

        var textDamage = pool.GetFreeElement();
        textDamage.transform.localPosition = positionText;
        textDamage.GetComponent<TextMeshPro>().text = $"- {damage}";
        StartCoroutine(ReturnToPoolAfterDelay(textDamage, 2f));
    }
    
    private IEnumerator ReturnToPoolAfterDelay(TextDamage textDamage, float delay)
    {
        yield return new WaitForSeconds(delay);
        pool.SetObject(textDamage);
    }
}