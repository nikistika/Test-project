using UnityEngine;
using UnityEngine.Serialization;

namespace Data.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "ArcherData", menuName = "CharactersData/NewArcherData")]
    public class ArcherData : BaseCharacterData

    {
        [SerializeField] private string _effectName = "Отравление";
        [SerializeField, Min(0)] private float _effectTime;
        [SerializeField, Min(0)] private int _effectDamage;
        [SerializeField, Min(0)] private float _intervalDamage;
        [SerializeField, Range(0, 100)] private int _effectChancePercent;

        public string EffectName => _effectName;
        public float EffectTime => _effectTime;
        public int EffectDamage => _effectDamage;
        public float IntervalDamage => _intervalDamage;
        public int EffectChance => _effectChancePercent;

        
    }
}