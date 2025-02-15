using System.Collections;
using Data.Scriptable_Objects;
using DefaultNamespace;
using UnityEngine;

namespace Characters
{
    public class Warrior : BaseCharacter<WarriorData>
    {

        internal override void Attack(GameObject enemy, int damage)
        {
            base.Attack(enemy, damage);

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
            effectName = $"{data.CharacterName} оглушает врага";
            gameObject.GetComponent<InteractionData>().CreateTextView(effectName, positionTextEffect);
            Enemy.GetComponent<InteractionData>().stunEffect = true;
            yield return new WaitForSeconds(effectTime);
            Enemy.GetComponent<InteractionData>().stunEffect = false;
            
            _effectCharacter = false;
        }
    }
}