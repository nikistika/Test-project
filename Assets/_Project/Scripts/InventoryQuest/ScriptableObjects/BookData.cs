using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "NewBookData", menuName = "ItemData/NewBookData")]
    public class BookData : ItemData
    {
        [field: SerializeField] public bool ReadIt { get; private set; }
    }
}