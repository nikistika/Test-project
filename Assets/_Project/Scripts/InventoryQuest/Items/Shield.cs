using Scriptable_Objects;
using UnityEngine;

namespace Items
{
    public class Shield : Weapon
    {
        private ShieldData _shieldData;

        private void Awake()
        {
            _shieldData = ItemData as ShieldData;
            Stackable = _shieldData.Stackable;
            
            positionPrefab = new(0.35f, 0, -0.13f);
            rotationPrefab = Quaternion.Euler(-72, -282, 36);
        }
        
    }
}