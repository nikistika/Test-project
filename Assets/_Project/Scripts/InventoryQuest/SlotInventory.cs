using Items;
using UnityEngine;

namespace _Project.Scripts.InventoryQuest
{
    public class SlotInventory : MonoBehaviour
    {
        
        public Item CurrentSlotItem { get; private set; }

        public void AddNewItemInCurrentSlot(Item item)
        {
            CurrentSlotItem = Instantiate(item.gameObject, transform).GetComponent<Item>();
            CurrentSlotItem.ActivateStatusText();
        }
        
        
    }
}