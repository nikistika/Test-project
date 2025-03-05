using UnityEngine;

namespace Items
{
    public class Weapon : Item
    {
        protected Vector3 positionPrefab;
        protected Quaternion rotationPrefab;
        
        public override void ItemEffect()
        {
            if (RightHand.CurrentWeapon != null)
            {
                var currentWeaponItem = RightHand.CurrentWeaponItem;

                if (currentWeaponItem != null)
                {
                    RightHand.ReturnCurrentWeaponInInventory();
                    Destroy(RightHand.CurrentWeapon);
                    Destroy(currentWeaponItem.gameObject);
                }
            }

            Item newItem = Instantiate(this);
            newItem.Construct(PanelHP, InventoryMenu, RightHand);
            RightHand.TakeWeapon(newItem, positionPrefab, rotationPrefab);

            Destroy(gameObject);
        }
        
    }
}