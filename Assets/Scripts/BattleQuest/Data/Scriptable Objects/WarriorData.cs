using UnityEngine;

namespace Data.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "WarriorData", menuName = "CharactersData/NewWarriorData")]
    public class WarriorData : BaseCharacterData

    {
        [SerializeField] private string _effectName = "Оглушение";
        [SerializeField, Min(0)] private int _effectTime;
        [SerializeField, Range(0, 100)] private int _effectChance;
        
        
        public string EffectName => _effectName;
        public int EffectTime => _effectTime;
        public int EffectChance => _effectChance;
        
    }
}