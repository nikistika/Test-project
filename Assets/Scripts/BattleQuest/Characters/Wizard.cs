using System.Collections;
using Data.Scriptable_Objects;
using DefaultNamespace;
using UnityEngine;

public class Wizard : BaseCharacter<WizardData>
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

            StartCoroutine(DebuffEnemy(data.EffectTime, data.EffectDebuff));
        }
    }

    private IEnumerator DebuffEnemy(float effectTime, int debuffDamagePercent)
    {
        effectName = $"{data.CharacterName} ослабляет врага";
        gameObject.GetComponent<InteractionData>().CreateTextView(effectName, positionTextEffect);

        Enemy.GetComponent<InteractionData>().debuffEffect = true;
        Enemy.GetComponent<InteractionData>().debuffPercent = debuffDamagePercent;
        yield return new WaitForSeconds(effectTime);
        Enemy.GetComponent<InteractionData>().debuffEffect = false;

        _effectCharacter = false;
    }
}