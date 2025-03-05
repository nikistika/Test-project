using InventoryQuest;
using Items;
using Scriptable_Objects;
using UnityEngine;

namespace InventoryQuest
{
    public class RightHandState : MonoBehaviour
    {
        public GameObject CurrentWeapon { get; private set; }
        public Item CurrentWeaponItem { get; private set; }

        [SerializeField] protected InventoryMenu InventoryMenu;


        public void TakeWeapon(Item weapon, Vector3 position, Quaternion rotation)
        {
            CurrentWeaponItem = weapon;

            var weaponData = weapon.ItemData as WeaponData;
            CurrentWeapon = Instantiate(weaponData.Prefab, transform);
            CurrentWeapon.transform.localPosition = position;
            CurrentWeapon.transform.localRotation = rotation;
            InventoryMenu.RemoveWeightFromInventory(CurrentWeaponItem.ItemData.WeightItem);
        }

        public void ReturnCurrentWeaponInInventory()
        {
            var freeSlotInventory = InventoryMenu.ReturnFirstFreeSlot();
            CurrentWeaponItem.AddNewItem(freeSlotInventory, CurrentWeaponItem);
            InventoryMenu.AddWeightInInventory(CurrentWeaponItem.ItemData.WeightItem);
        }
    }
}