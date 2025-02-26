using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "WarriorData", menuName = "CharactersData/NewWarriorData")]
    public class WarriorData : BaseCharacterData

    {
        
        [field: SerializeField] public string EffectName { get; private set; }
        [field: SerializeField, Min(0)] public int EffectTime { get; private set; }
        [field: SerializeField, Range(0, 100)] public int EffectChance { get; private set; }
        
    }
}