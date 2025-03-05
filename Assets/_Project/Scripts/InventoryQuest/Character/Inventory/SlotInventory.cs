using Items;
using UnityEngine;

namespace InventoryQuest
{
    public class SlotInventory : MonoBehaviour
    {
        
        public Item CurrentSlotItem { get; private set; }

        public void AddNewItemInCurrentSlot(Item item)
        {
            CurrentSlotItem = Instantiate(item.gameObject, transform).GetComponent<Item>();
            CurrentSlotItem.Construct(item.PanelHP, item.InventoryMenu, item.RightHand);

            CurrentSlotItem.AddItemsToStack(1);
            CurrentSlotItem.ActivateStatusText();

        }

        public void OnDestroySlotItem()
        {
            Destroy(CurrentSlotItem);
        }

        public void OnClickItem()
        {
            CurrentSlotItem.ItemEffect();
        }
        
        
    }
}