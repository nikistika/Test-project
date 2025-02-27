using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;

namespace Characters
{
    public class Wizard : BaseCharacter<WizardData>
    {
        // protected override void Attack(GameObject enemy, int damage)
        // {
        //     base.Attack(enemy, damage);
        //
        //     if (EffectCharacter == false) TryExecuteCoroutine(Data.EffectChance);
        // }
        
        protected override void ApplyEffect()
        {
            if (Random.Range(0f, 100f) < Data.EffectChance)
            {
                EffectCharacter = true;

                StartCoroutine(DebuffEnemy(Data.EffectTime, Data.EffectDebuff));
            }
        }

        // void TryExecuteCoroutine(int chancePercent)
        // {
        //     if (Random.Range(0f, 100f) < chancePercent)
        //     {
        //         EffectCharacter = true;
        //
        //         StartCoroutine(DebuffEnemy(Data.EffectTime, Data.EffectDebuff));
        //     }
        // }

        private IEnumerator DebuffEnemy(float effectTime, int debuffDamagePercent)
        {
            EffectName = $"{Data.CharacterName} ослабляет врага";
            gameObject.GetComponent<InteractionData>().CreateTextView(EffectName, PositionTextEffect);

            Enemy.GetComponent<InteractionData>().DebuffEffect = true;
            Enemy.GetComponent<InteractionData>().DebuffPercent = debuffDamagePercent;
            yield return new WaitForSeconds(effectTime);
            Enemy.GetComponent<InteractionData>().DebuffEffect = false;

            EffectCharacter = false;
        }
    }
}