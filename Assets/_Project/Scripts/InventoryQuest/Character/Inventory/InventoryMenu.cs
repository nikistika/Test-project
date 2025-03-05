using System.Collections.Generic;
using InventoryQuest;
using Items;
using TMPro;
using UnityEngine;

namespace InventoryQuest
{
    public class InventoryMenu : MonoBehaviour
    {
        [field: SerializeField] public List<SlotInventory> Slots { get; private set; }
        [field: SerializeField] public float InventoryMaxWeight { get; private set; }
        [field: SerializeField] public float CurrentWeight { get; private set; }

        [SerializeField] private TMP_Text _countWeightText;

        private void Awake()
        {
            _countWeightText.text = $"Максимальный вес: {CurrentWeight}/{InventoryMaxWeight}";
        }

        public void OpenCloseInventory()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void AddWeightInInventory(float weight)
        {
            if (CurrentWeight + weight <= InventoryMaxWeight)
            {
                CurrentWeight += weight;
                _countWeightText.text = $"Максимальный вес: {CurrentWeight}/{InventoryMaxWeight}";
            }
        }

        public void RemoveWeightFromInventory(float weight)
        {
            if (CurrentWeight - weight >= 0)
            {
                CurrentWeight -= weight;
                _countWeightText.text = $"Максимальный вес: {CurrentWeight}/{InventoryMaxWeight}";
            }
        }

        public SlotInventory ReturnFirstFreeSlot()
        {
            foreach (var slot in Slots)
            {
                if (slot.CurrentSlotItem == null)
                {
                    return slot;
                }
            }

            return null;
        }

        public Item ReturnStackableItemFromSlot(Item item)
        {
            foreach (var slot in Slots)
            {
                if (slot.transform.childCount != 0)
                {
                    Item inventoryItem = slot.transform.GetChild(0).GetComponent<Item>();
                    if (inventoryItem.CurrentCount < inventoryItem.ItemData.MaxCount)
                    {
                        string inventoryItemName = inventoryItem.ItemData.NameItem;
                        string addPanelItemName = item.ItemData.NameItem;

                        if (inventoryItemName == addPanelItemName)
                        {
                            return inventoryItem;
                        }
                    }
                }
            }

            return null;
        }
    }
}