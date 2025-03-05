using Scriptable_Objects;
using UnityEngine;

namespace Items
{
    public class Mace : Weapon
    {
        private MaceData _maceData;

        private void Awake()
        {
            _maceData = ItemData as MaceData;
            Stackable = _maceData.Stackable;
            positionPrefab = new(0.11f, -0.03f, -0.27f);
            rotationPrefab = Quaternion.Euler(-32.7f, -86.82f, -93.48f);
        }


    }
}