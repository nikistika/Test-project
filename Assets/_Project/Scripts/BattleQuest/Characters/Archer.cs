using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters
{
    public class Archer : BaseCharacter<ArcherData>
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

                StartCoroutine(PoisonEffect(Data.EffectTime, Data.EffectDamage, Data.IntervalDamage));
            }
        }

        // private void TryExecuteCoroutine(int chancePercent)
        // {
        //     if (Random.Range(0f, 100f) < chancePercent)
        //     {
        //         EffectCharacter = true;
        //
        //         StartCoroutine(PoisonEffect(Data.EffectTime, Data.EffectDamage, Data.IntervalDamage));
        //     }
        // }

        private IEnumerator PoisonEffect(float effectTime, int effectDamage, float intervalDamage)
        {
            EffectName = $"{Data.CharacterName} отравляет врага";
            gameObject.GetComponent<InteractionData>().CreateTextView(EffectName, PositionTextEffect);

            float elapsedTime = 0f;

            while (elapsedTime < effectTime)
            {
                Enemy.GetComponent<InteractionData>().GetDamage(effectDamage);

                yield return new WaitForSeconds(intervalDamage);
                elapsedTime += intervalDamage;
            }

            EffectCharacter = false;
        }
    }
}