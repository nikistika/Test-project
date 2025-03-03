using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "NewPotionData", menuName = "ItemData/NewPotionData")]
    public class PotionData : ItemData
    {
        [field: SerializeField] public int HealQuantity { get; private set; }
    }
}