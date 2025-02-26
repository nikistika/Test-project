using UnityEngine;

namespace Scriptable_Objects
{
    public abstract class ItemData : ScriptableObject
    {

        [field: SerializeField] public string NameItem { get; private set; }
        [field: SerializeField] public Sprite AssetImage { get; private set; }
        [field: SerializeField] public bool Stackable { get; private set; }
        [field: SerializeField] public float WeightItem { get; private set; }
    }
}