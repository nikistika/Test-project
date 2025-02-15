using UnityEngine;
using UnityEngine.Serialization;

namespace Data.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "WizardData", menuName = "CharactersData/NewWizardData")]
    public class WizardData : BaseCharacterData

    {
        [SerializeField] private string _effectName = "Ослабление";
        [SerializeField, Min(0)] private float _effectTime;
        [SerializeField, Range(0, 100)] private int _effectChance;
        [SerializeField, Range(0, 100)] private int _effectDebuffPercent;
        
        public string EffectName => _effectName;
        public float EffectTime => _effectTime;
        public int EffectDebuff => _effectDebuffPercent;
        
        public int EffectChance => _effectDebuffPercent;
        
    }
}