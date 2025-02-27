using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;

namespace Characters
{
    public class Warrior : BaseCharacter<WarriorData>
    {
        // protected override void Attack(GameObject enemy, int damage)
        // {
        //     base.Attack(enemy, damage);
        //
        //     TryExecuteCoroutine(Data.EffectChance);
        // }

        protected override void ApplyEffect()
        {
            if (Random.value < Data.EffectChance)
            {
                EffectCharacter = true;

                StartCoroutine(StunEnemy(Data.EffectTime));
            }
        }
        
        // void TryExecuteCoroutine(int chancePercent)
        // {
        //     if (Random.Range(0f, 100f) < chancePercent)
        //     {
        //         EffectCharacter = true;
        //
        //         StartCoroutine(StunEnemy(Data.EffectTime));
        //     }
        // }

        private IEnumerator StunEnemy(float effectTime)
        {
            if (Enemy == null) yield break;

            EffectName = $"{Data.CharacterName} оглушает врага";
            gameObject.GetComponent<InteractionData>().CreateTextView(EffectName, PositionTextEffect);
            Enemy.GetComponent<InteractionData>().StunEffect = true;
            yield return new WaitForSeconds(effectTime);
            Enemy.GetComponent<InteractionData>().StunEffect = false;

            EffectCharacter = false;
        }
    }
}