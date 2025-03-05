using Items;
using UnityEngine;

namespace InventoryQuest
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
            var newItem =
                Instantiate(CurrentSlotItem.gameObject, gameObject.transform)
                    .GetComponent<Item>(); // Создаём копию в сцене
            newItem.Construct(item.PanelHP, item.InventoryMenu, item.RightHand);
        }

        public void OnClickItem()
        {
            if (!CurrentSlotItem.ItemData.Stackable &&
                CurrentSlotItem != null &&
                _inventoryMenu.CurrentWeight + CurrentSlotItem.ItemData.WeightItem <= _inventoryMenu.InventoryMaxWeight)
            {
                CurrentSlotItem.AddNewItem
                    (_inventoryMenu.ReturnFirstFreeSlot(), CurrentSlotItem);

                _inventoryMenu.AddWeightInInventory(CurrentSlotItem.ItemData.WeightItem);
            }

            if (CurrentSlotItem.ItemData.Stackable &&
                CurrentSlotItem != null &&
                _inventoryMenu.CurrentWeight + CurrentSlotItem.ItemData.WeightItem <= _inventoryMenu.InventoryMaxWeight)
            {
                Item stackableItemInventory = _inventoryMenu.ReturnStackableItemFromSlot(CurrentSlotItem);

                if (stackableItemInventory != null &&
                    stackableItemInventory.CurrentCount < stackableItemInventory.ItemData.MaxCount)
                {
                    stackableItemInventory.AddItemsToStack(1);
                    _inventoryMenu.AddWeightInInventory(CurrentSlotItem.ItemData.WeightItem);
                }
                else
                {
                    Debug.Log("else OnClickItem");
                    CurrentSlotItem.AddNewItem
                        (_inventoryMenu.ReturnFirstFreeSlot(), CurrentSlotItem);

                    _inventoryMenu.AddWeightInInventory(CurrentSlotItem.ItemData.WeightItem);
                }
            }
        }
    }
}