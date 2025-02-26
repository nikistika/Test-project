using System.Collections.Generic;
using Items;
using TMPro;
using UnityEngine;

namespace InventoryUI
{
    
    public class Inventory : MonoBehaviour
    {
        [field: SerializeField] public List<GameObject> Slots { get; private set; }
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

        public void RemoveInFroInventory(float weight)
        {
            if (CurrentWeight - weight >= 0)
            {
                CurrentWeight -= weight;
                _countWeightText.text = $"Максимальный вес: {CurrentWeight}/{InventoryMaxWeight}";
            }
        }
    }
}