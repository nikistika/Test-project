using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "WizardData", menuName = "CharactersData/NewWizardData")]
    public class WizardData : BaseCharacterData

    {
        [field: SerializeField] public string EffectName { get; private set;}
        [field: SerializeField, Min(0)] public float EffectTime { get; private set;}
        [field: SerializeField, Range(0, 100)] public int EffectDebuff { get; private set;}
        [field: SerializeField, Range(0, 1)] public float EffectChance { get; private set;}
        
    }
}