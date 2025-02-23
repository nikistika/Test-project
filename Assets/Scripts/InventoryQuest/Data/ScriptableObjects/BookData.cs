using UnityEngine;

[CreateAssetMenu(fileName = "NewBookData", menuName = "ItemData/NewBookData")]
public class BookData : ItemData
{
    
    [SerializeField] private bool _readIt;
    
    public bool ReadIt => _readIt;

}
