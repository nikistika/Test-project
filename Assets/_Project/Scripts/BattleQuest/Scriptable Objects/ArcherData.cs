using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "ArcherData", menuName = "CharactersData/NewArcherData")]
    public class ArcherData : BaseCharacterData

    {
        
        [field:SerializeField] public string EffectName { get; private set; }
        [field:SerializeField, Min(0)] public float EffectTime { get; private set; }
        [field:SerializeField, Min(0)] public int EffectDamage { get; private set; }
        [field:SerializeField, Min(0)] public float IntervalDamage { get; private set; }
        [field:SerializeField, Range(0, 1)] public float EffectChance { get; private set; }
    }
}