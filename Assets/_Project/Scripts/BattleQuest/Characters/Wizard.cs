using System.Collections;
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
            
            Enemy.CreateTextView(EffectName, PositionTextEffect);

            Enemy.StateDebuffEffect(true, debuffDamagePercent);
            yield return new WaitForSeconds(effectTime);
            Enemy.StateDebuffEffect(false);

            EffectCharacter = false;
        }
    }
}