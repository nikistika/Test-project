using System.Collections;
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
            
            if (Enemy == null) yield break;

            EffectName = $"Получает эффект {Data.EffectName}";
            Enemy.CreateTextView(EffectName, PositionTextEffect);
            Enemy.StateDebuffEffect(true);
            yield return new WaitForSeconds(effectTime);
            Enemy.StateDebuffEffect(false);

            EffectCharacter = false;
        }
    }
}