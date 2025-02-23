using UnityEngine;

[CreateAssetMenu(fileName = "NewMaceData", menuName = "ItemData/NewMaceData")]
public class MaceData : ItemData
{
    
    [SerializeField] private GameObject _prefab;

    public GameObject prefub => _prefab;
    
}
