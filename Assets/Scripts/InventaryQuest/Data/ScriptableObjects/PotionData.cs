using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPotionData", menuName = "ItemData/NewPotionData")]
public class PotionData : ItemData
{
    private int _maxCount;
    private int _healQuantity;

    public int MaxCount => _maxCount;
    public int HealQuantity => _healQuantity;

}
