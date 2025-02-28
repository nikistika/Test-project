using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;

namespace Characters
{
    public class Wizard : BaseCharacter<WizardData>
    {

        protected override void ApplyEffect()
        {
            if (Random.value < Data.EffectChance)
            {
                EffectCharacter = true;

                StartCoroutine(DebuffEnemy(Data.EffectTime, Data.EffectDebuff));
            }
        }

        private IEnumerator DebuffEnemy(float effectTime, int debuffDamagePercent)
        {
            EffectName = $"Получает эффект {Data.EffectName}";
            Enemy.GetComponent<InteractionData>().CreateTextView(EffectName, PositionTextEffect);

            Enemy.GetComponent<InteractionData>().DebuffEffect = true;
            Enemy.GetComponent<InteractionData>().DebuffPercent = debuffDamagePercent;
            yield return new WaitForSeconds(effectTime);
            Enemy.GetComponent<InteractionData>().DebuffEffect = false;

            EffectCharacter = false;
        }
    }
}