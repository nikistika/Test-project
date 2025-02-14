using System;
using System.Collections;
using Data.Scriptable_Objects;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Archer : BaseCharacter<ArcherData>
{

    void Start()
    {
        base.Start();
    }
    
    internal override void Attack(GameObject enemy)
    {
        base.Attack(enemy);
        
        if (_effectCharacter == false) TryExecuteCoroutine(data.EffectDamage);
    }

    void TryExecuteCoroutine(int chancePercent)
    {
        if (Random.Range(0f, 100f) < chancePercent)
        {
            _effectCharacter = true;
            Debug.LogWarning("PoisonEffect started");
            
            StartCoroutine(PoisonEffect(data.EffectTime, data.EffectDamage, data.IntervalDamage));
        }
    }

    private IEnumerator PoisonEffect(float effectTime, int effectDamage, float intervalDamage)
    {
        float elapsedTime = 0f; // Прошедшее время

        while (elapsedTime < effectTime) // Пока эффект не закончился
        {
            
            HitEnemy(Enemy, effectDamage);

            yield return new WaitForSeconds(intervalDamage); // Ждём перед следующим уроном
            elapsedTime += intervalDamage; // Увеличиваем время действия яда
        }

        _effectCharacter = false;
        Debug.Log("Эффект яда закончился!");
    }
}
    