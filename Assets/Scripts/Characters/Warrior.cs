using System.Collections;
using Data.Scriptable_Objects;
using UnityEngine;

namespace Characters
{
    public class Warrior : BaseCharacter<WarriorData>
    {

        internal override void Attack(GameObject enemy)
        {
            base.Attack(enemy);

            TryExecuteCoroutine(data.EffectChance);
        }
        
        void TryExecuteCoroutine(int chancePercent)
        {
            if (Random.Range(0f, 100f) < chancePercent)
            {
                _effectCharacter = true;
                Debug.LogWarning("PoisonEffect started");
            
                StartCoroutine(StunEnemy(data.EffectTime));
            }
        }
        
        private IEnumerator StunEnemy(float effectTime)
        {
            
            
            
        }
    }
}