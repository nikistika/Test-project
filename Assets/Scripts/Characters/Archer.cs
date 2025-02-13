using System.Collections;
using System.Collections.Generic;
using Data.Scriptable_Objects;
using UnityEngine;

public class Archer : BaseCharactersMonoBehaviour<ArcherScriptableObject>
{

    private bool _effectCharacter;
    
    // internal override void Attack(GameObject enemy)
    // {
    //     base.Attack(enemy);
    //     
    //     // if (_effectCharacter == false) TryExecuteCoroutine(data.EffectDamage);
    // }
    
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

            enemy.GetComponent<BaseCharactersMonoBehaviour<BaseCharacterScriptableObject>>().GetDamage(effectDamage);
            
            yield return new WaitForSeconds(intervalDamage); // Ждём перед следующим уроном
            elapsedTime += intervalDamage; // Увеличиваем время действия яда
        }

        _effectCharacter = false;
        Debug.Log("Эффект яда закончился!");
    }
    
}
