using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPotionData", menuName = "ItemData/NewPotionData")]
public class PotionData : ItemData
{
    [SerializeField] private int _maxCount;
    [SerializeField] private int _healQuantity;

    public int MaxCount => _maxCount;
    public int HealQuantity => _healQuantity;

}
