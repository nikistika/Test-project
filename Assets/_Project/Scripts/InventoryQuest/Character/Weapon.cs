using _Project.Scripts.InventoryQuest;
using InventoryUI;
using Items;
using UnityEngine;

namespace Character
{
    
    public class Weapon : MonoBehaviour
    {
        private PanelAddItem _panelAddItem;
        private InventoryMenu _inventoryMenu;

        // private void Awake()
        // {
        //     _panelAddItem = GameObject.Find("PanelAddItem").GetComponent<PanelAddItem>();
        //     _inventoryMenu = GameObject.Find("InventaryMenu").GetComponent<InventoryMenu>();
        // }
        //
        // public void ReturnItemInInventory()
        // {
        //     GameObject freeSlot = ScanSlots();
        //
        //     if (gameObject.name == "Mace(Clone)")
        //     {
        //         Mace mace = _panelAddItem.Items[3].GetComponent<Mace>();
        //         if (mace == null)
        //         {
        //             return;
        //         }
        //
        //         mace.ClickAddItemPanelAction(freeSlot);
        //     }
        //
        //     if (gameObject.name == "Shield(Clone)")
        //     {
        //         Shield shield = _panelAddItem.Items[2].GetComponent<Shield>();
        //         shield.ClickAddItemPanelAction(freeSlot);
        //
        //         if (shield == null)
        //         {
        //             return;
        //         }
        //     }
        //
        //     Destroy(gameObject);
        // }
        //
        // private SlotInventory ScanSlots()
        // {
        //     foreach (SlotInventory slot in _inventoryMenu.Slots)
        //     {
        //         if (slot.transform.childCount == 0)
        //         {
        //             return slot;
        //         }
        //     }
        //
        //     return null;
        // }
    }
}