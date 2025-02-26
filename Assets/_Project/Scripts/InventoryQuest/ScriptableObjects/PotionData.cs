using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "NewPotionData", menuName = "ItemData/NewPotionData")]
    public class PotionData : ItemData
    {
        [field: SerializeField] public int MaxCount { get; private set; }
        [field: SerializeField] public int HealQuantity { get; private set; }
    }
}