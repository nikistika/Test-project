using System.Collections.Generic;
using _Project.Scripts.InventoryQuest;
using Items;
using TMPro;
using UnityEngine;

namespace InventoryUI
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
                Debug.Log($"CurrentWeight in inventory: {CurrentWeight}");

            }
        }

        public void RemoveFromInventory(float weight)
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

                Debug.Log($"slot: {slot}");
                Debug.Log($"CurrentSlotItem: {slot.CurrentSlotItem}");
                
                if (slot.CurrentSlotItem == null)
                {
                    Debug.Log("Return slot");
                    return slot;
                }
            }

            return null;
        }
        
    }
}