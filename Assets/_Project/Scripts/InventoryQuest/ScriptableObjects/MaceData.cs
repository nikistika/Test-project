using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "NewMaceData", menuName = "ItemData/NewMaceData")]
    public class MaceData : ItemData
    {
        [field: SerializeField] public GameObject Prefub { get; private set; }
    }
}