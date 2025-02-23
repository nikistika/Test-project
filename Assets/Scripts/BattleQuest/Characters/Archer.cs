using System.Collections;
using Data.Scriptable_Objects;
using DefaultNamespace;
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

            StartCoroutine(PoisonEffect(data.EffectTime, data.EffectDamage, data.IntervalDamage));
        }
    }

    private IEnumerator PoisonEffect(float effectTime, int effectDamage, float intervalDamage)
    {
        effectName = $"{data.CharacterName} отравляет врага";
        gameObject.GetComponent<InteractionData>().CreateTextView(effectName, positionTextEffect);

        float elapsedTime = 0f; 

        while (elapsedTime < effectTime) 
        {
            Enemy.GetComponent<InteractionData>().GetDamage(effectDamage);

            yield return new WaitForSeconds(intervalDamage); 
            elapsedTime += intervalDamage;
        }

        _effectCharacter = false;
    }
}