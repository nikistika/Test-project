using Character;
using Items;
using Scriptable_Objects;
using UnityEngine;

namespace Items
{
    public class Mace : Item
    {
        private MaceData _maceData;

        private void Awake()
        {

            _maceData = ItemData as MaceData;
            Stackable = _maceData.Stackable;

        }
        
        

        // public override void ClickAddItemPanelAction(GameObject slot)
        // {
        //     if (InventoryMenu.InventoryMaxWeight >= InventoryMenu.CurrentWeight + _maceData.WeightItem)
        //     {
        //         NewItem = Instantiate(gameObject, slot.transform);
        //         TextNewItem = NewItem.GetComponent<Mace>().StatusText;
        //
        //         InventoryMenu.AddWeightInInventory(_maceData.WeightItem);
        //         TextNewItem.SetActive(true);
        //     }
        // }

        // protected override void ClickInventoryPanelAction()
        // {
        //     GameObject handRight = GameObject.FindGameObjectWithTag("Hand_r");
        //     bool hasChildWithTag = false;
        //     GameObject otherWeapon = null;
        //     foreach (Transform child in handRight.transform)
        //     {
        //         if (child.CompareTag("Weapon")) // Проверка тега
        //         {
        //             hasChildWithTag = true;
        //             otherWeapon = child.gameObject;
        //             break; // Если нашли, можно сразу выйти из цикла
        //         }
        //     }
        //
        //     // if (hasChildWithTag && otherWeapon != null)
        //     // {
        //     //     otherWeapon.GetComponent<Weapon>().ReturnItemInInventory();
        //     // }
        //
        //     Vector3 positionPrefab = new(0.04f, -0.05f, -0.38f);
        //     Quaternion rotationPrefab = Quaternion.Euler(-22.03f, 102.94f, 88.974f);
        //
        //     GameObject newMace = Instantiate(_maceData.Prefub, _hand_r.transform);
        //     newMace.transform.localPosition = positionPrefab;
        //     newMace.transform.localRotation = rotationPrefab;
        //
        //     Destroy(gameObject);
        //     InventoryMenu.RemoveFromInventory(_maceData.WeightItem);
        // }
    }
}