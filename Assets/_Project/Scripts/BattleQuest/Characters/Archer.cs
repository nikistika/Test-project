using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters
{
    public class Archer : BaseCharacter<ArcherData>
    {

        protected override void ApplyEffect()
        {
            if (Random.value < Data.EffectChance)
            {
                EffectCharacter = true;

                StartCoroutine(PoisonEffect());
            }
        }


        private IEnumerator PoisonEffect()
        {

            EffectName = $"Получает эффект {Data.EffectName}";
            Enemy.GetComponent<InteractionData>().CreateTextView(EffectName, PositionTextEffect);


            float elapsedTime = 0f;

            while (elapsedTime < Data.EffectTime)
            {
                Enemy.GetComponent<InteractionData>().GetDamage(Data.EffectDamage);

                yield return new WaitForSeconds(Data.IntervalDamage);
                elapsedTime += Data.IntervalDamage;
            }

            EffectCharacter = false;
        }
    }
}