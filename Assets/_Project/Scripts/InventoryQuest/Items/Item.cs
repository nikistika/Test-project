using Chatacter;
using InventoryQuest;
using Scriptable_Objects;
using TMPro;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {

        [SerializeField] protected TMP_Text StatusText;
        
        public int CurrentCount { get; private set; }
        public HP_Panel PanelHP { get; private set; }
        public InventoryMenu InventoryMenu { get; private set; }
        public RightHandState RightHand { get; protected set; }
        public bool Stackable { get; protected set; }
        
        [field: SerializeField] public ItemData ItemData { get; protected set; }


        public void Construct(HP_Panel hpPanel, InventoryMenu inventoryMenu, RightHandState rightHandRight)
        {
            PanelHP = hpPanel;
            InventoryMenu = inventoryMenu;
            RightHand = rightHandRight;
        }

        public void ActivateStatusText()
        {
            StatusText.gameObject.SetActive(true);
        }

        public bool AddItemsToStack(int amount)
        {
            if (CurrentCount + amount <= ItemData.MaxCount)
            {
                CurrentCount += amount;
                StatusText.text = $"{CurrentCount}/{ItemData.MaxCount}";
                return true;
            }

            return false;
        }

        public void RemoveItemFromStack(int amount)
        {
            CurrentCount -= amount;
            StatusText.text = $"{CurrentCount}/{ItemData.MaxCount}";
        }


        public void AddNewItem(SlotInventory slot, Item item)
        {
            slot.AddNewItemInCurrentSlot(item);
        }

        public virtual void ItemEffect()
        {
        }
    }
}