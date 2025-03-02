using System.Collections;
using Scriptable_Objects;
using UnityEngine;

namespace Characters
{
    public class Archer : BaseCharacterGeneric<ArcherData>
    {
        protected override void ApplyEffect()
        {
            if (TryApplyEffect(Data.EffectChance))
            {
                StartCoroutine(PoisonEffect());
            }
        }


        private IEnumerator PoisonEffect()
        {
            EffectName = $"Получает эффект {Data.EffectName}";
            Enemy.CreateTextView(EffectName, PositionTextEffect);


            float elapsedTime = 0f;

            while (elapsedTime < Data.EffectTime)
            {
                Enemy.GetDamage(Data.EffectDamage);

                yield return new WaitForSeconds(Data.IntervalDamage);
                elapsedTime += Data.IntervalDamage;
            }

            EffectCharacter = false;
        }
    }
}