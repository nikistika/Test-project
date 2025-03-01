using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;

namespace Characters
{
    public class Wizard : BaseCharacterGeneric<WizardData>
    {

        protected override void ApplyEffect()
        {
            if (TryApplyEffect(Data.EffectChance))
            {
                StartCoroutine(DebuffEnemy(Data.EffectTime, Data.EffectDebuff));
            }
        }

        private IEnumerator DebuffEnemy(float effectTime, int debuffDamagePercent)
        {
            EffectName = $"Получает эффект {Data.EffectName}";

            EnemyInteractionData = Enemy.GetComponent<InteractionData>();
            
            EnemyInteractionData.CreateTextView(EffectName, PositionTextEffect);

            EnemyInteractionData.StateDebuffEffect(true, debuffDamagePercent);
            yield return new WaitForSeconds(effectTime);
            EnemyInteractionData.StateDebuffEffect(false);

            EffectCharacter = false;
        }
    }
}