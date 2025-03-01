using System.Collections;
using BattleQuest;
using Scriptable_Objects;
using UnityEngine;

namespace Characters
{
    public class Warrior : BaseCharacterGeneric<WarriorData>
    {

        protected override void ApplyEffect()
        {
            if (TryApplyEffect(Data.EffectChance))
            {
                StartCoroutine(StunEnemy(Data.EffectTime));
            }
        }
        

        private IEnumerator StunEnemy(float effectTime)
        {
            EnemyInteractionData = Enemy.GetComponent<InteractionData>();
            
            if (Enemy == null) yield break;

            EffectName = $"Получает эффект {Data.EffectName}";
            EnemyInteractionData.CreateTextView(EffectName, PositionTextEffect);
            EnemyInteractionData.StateDebuffEffect(true);
            yield return new WaitForSeconds(effectTime);
            EnemyInteractionData.StateDebuffEffect(false);

            EffectCharacter = false;
        }
    }
}