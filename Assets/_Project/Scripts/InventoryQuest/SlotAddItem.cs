using InventoryUI;
using Items;
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
                _inventoryMenu.CurrentWeight + CurrentSlotItem.WeightItem != _inventoryMenu.InventoryMaxWeight)
            {
                Debug.Log("OnClickItem");
                CurrentSlotItem.ClickAddItemPanelAction
                    (_inventoryMenu.ReturnFirstFreeSlot(), CurrentSlotItem);
                
                Debug.Log($"CurrentSlotItem.WeightItem: {CurrentSlotItem.WeightItem}");
                
                _inventoryMenu.AddWeightInInventory(CurrentSlotItem.WeightItem);
            }
        }
    }
}