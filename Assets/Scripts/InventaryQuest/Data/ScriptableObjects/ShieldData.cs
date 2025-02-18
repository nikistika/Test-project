using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewShieldData", menuName = "ItemData/NewShieldData")]
public class ShieldData : ItemData
{
    
    [SerializeField] private GameObject _prefab;

    public GameObject prefub => _prefab;
    
}
