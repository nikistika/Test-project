using UnityEngine;

[CreateAssetMenu(fileName = "NewShieldData", menuName = "ItemData/NewShieldData")]
public class ShieldData : ItemData
{
    
    [SerializeField] private GameObject _prefab;

    public GameObject prefab => _prefab;
    
}
