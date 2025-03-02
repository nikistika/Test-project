using System.Collections.Generic;
using _Project.Scripts.InventoryQuest;
using Items;
using UnityEngine;

namespace InventoryUI
{
    
    public class PanelAddItem : MonoBehaviour
    {
        public List<GameObject> Items = new();
        
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