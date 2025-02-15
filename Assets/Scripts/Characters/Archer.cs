using System;
using System.Collections;
using Data.Scriptable_Objects;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Archer : BaseCharacter<ArcherData>
{
    
    internal override void Attack(GameObject enemy, int damage)
    {
        base.Attack(enemy, damage);
        
        if (_effectCharacter == false) TryExecuteCoroutine(data.EffectChance);
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
        
        effectName = $"{data.CharacterName} отравляет врага";
        gameObject.GetComponent<InteractionData>().CreateTextView(effectName, positionTextEffect);
        
        float elapsedTime = 0f; // Прошедшее время
        
        while (elapsedTime < effectTime) // Пока эффект не закончился
        {
            
            Enemy.GetComponent<InteractionData>().GetDamage(effectDamage);
            
            yield return new WaitForSeconds(intervalDamage); // Ждём перед следующим уроном
            elapsedTime += intervalDamage; // Увеличиваем время действия яда
        }

        _effectCharacter = false;
        Debug.Log("Эффект яда закончился!");
    }
}
    