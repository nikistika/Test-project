using System.Collections.Generic;
using InventoryQuest;
using Items;
using UnityEngine;

namespace InventoryQuest
{
    public class PanelAddItem : MonoBehaviour
    {
        
        [SerializeField] private List<SlotAddItem> _slots = new();

        public void Construct(List<Item> items)
        {
            foreach (var item in items)
            {
                AddItemInFreeSlot(item);
            }
        }

        public void AddItemInFreeSlot(Item item)
        {
            foreach (SlotAddItem slot in _slots)
            {
                if (slot.CurrentSlotItem == null)
                {
                    slot.AddItemInCurrentSlot(item);
                    break;
                }
            }
        }
    }
}