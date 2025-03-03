using InventoryUI;
using Items;
using Scriptable_Objects;
using UnityEngine;

namespace _Project.Scripts.InventoryQuest
{
    public class SlotAddItem : MonoBehaviour
    {
        
        private InventoryMenu _inventoryMenu;

        public Item CurrentSlotItem { get; private set; }
        
        public void Construct(InventoryMenu inventoryMenu)
        {
            _inventoryMenu = inventoryMenu;
        }
        

        public void AddItemInCurrentSlot(Item item)
        {
            CurrentSlotItem = item;
            Instantiate(CurrentSlotItem.gameObject, gameObject.transform); // Создаём копию в сцене

        }

        public void OnClickItem()
        {
            if (CurrentSlotItem != null && 
                !CurrentSlotItem.Stackable &&
                _inventoryMenu.CurrentWeight + CurrentSlotItem.ItemData.WeightItem <= _inventoryMenu.InventoryMaxWeight)
            {
                Debug.Log("OnClickItem");
                CurrentSlotItem.ClickAddItemPanelAction
                    (_inventoryMenu.ReturnFirstFreeSlot(), CurrentSlotItem);
                
                Debug.Log($"CurrentSlotItem.WeightItem: {CurrentSlotItem.ItemData.WeightItem}");
                
                _inventoryMenu.AddWeightInInventory(CurrentSlotItem.ItemData.WeightItem);
            }
        }
    }
}