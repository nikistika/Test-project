using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "NewShieldData", menuName = "ItemData/NewShieldData")]
    public class ShieldData : ItemData
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}