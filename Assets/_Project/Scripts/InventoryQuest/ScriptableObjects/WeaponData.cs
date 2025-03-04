using UnityEngine;

namespace Scriptable_Objects
{
    public class WeaponData : ItemData
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }

    }
}