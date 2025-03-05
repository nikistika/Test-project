using Chatacter;
using UnityEngine;

namespace Characters
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        protected VictoryPanel VictoryPanel;
        protected BaseCharacter Enemy;

        public string CharacterName { get; protected set; }

        public void Construct(VictoryPanel victoryPanel, BaseCharacter enemy)
        {
            VictoryPanel = victoryPanel;
            Enemy = enemy;
        }

        public virtual void GetDamage(int damage)
        {
        }


        public virtual void CreateTextView(string text, Vector3 positionText)
        {
        }

        public virtual void StateStunEffect(bool state)
        {
        }

        public virtual void StateDebuffEffect(bool state)
        {
        }

        public virtual void StateDebuffEffect(bool state, int debuffPercent)
        {
        }
    }
}