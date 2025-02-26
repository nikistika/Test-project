using UnityEngine;

namespace Scriptable_Objects
{
    public abstract class BaseCharacterData : ScriptableObject
    {
        
        [field: SerializeField] public string CharacterName {get; private set;}
        [field: SerializeField, Min(0)] public int Health {get; private set;}
        [field: SerializeField, Min(0)] public float SpeedAttack {get; private set;}
        [field: SerializeField, Min(0)] public int DamageMin {get; private set;}
        [field: SerializeField] public int DamageMax {get; private set;}
    }
}
