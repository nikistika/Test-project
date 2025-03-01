using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;
using Random = UnityEngine.Random;

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
            EnemyInteractionData = Enemy.GetComponent<InteractionData>();
                
            EffectName = $"Получает эффект {Data.EffectName}";
            EnemyInteractionData.CreateTextView(EffectName, PositionTextEffect);


            float elapsedTime = 0f;

            while (elapsedTime < Data.EffectTime)
            {
                EnemyInteractionData.GetDamage(Data.EffectDamage);

                yield return new WaitForSeconds(Data.IntervalDamage);
                elapsedTime += Data.IntervalDamage;
            }

            EffectCharacter = false;
        }
    }
}