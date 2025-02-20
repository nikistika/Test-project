using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    
    [SerializeField] private List<GameObject> _slots;
    [SerializeField] private float _inventoryMaxWeight;
    [SerializeField] private TMP_Text _countWeightText;
    
    private float _currentWeight;
    
    public List<GameObject> Slots => _slots;
    public float InventoryMaxWeight => _inventoryMaxWeight;
    public float CurrentWeight => _currentWeight;
    
    private void Awake()
    {
        _countWeightText.text = $"Максимальный вес: {_currentWeight}/{_inventoryMaxWeight}";
    }
    
    public void AddItem(Item item)
    {
        
    }

    public void OpenCloseInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf); 
    }

    public void AddWeightInInventory(float weight)
    {
        if (_currentWeight + weight <= _inventoryMaxWeight)
        {
             _currentWeight += weight;
             _countWeightText.text = $"Максимальный вес: {_currentWeight}/{_inventoryMaxWeight}";
        }

    }

        public void RemoveInFroInventory(float weight)
    {
        if (_currentWeight - weight >= 0)
        {
            _currentWeight -= weight;
            _countWeightText.text = $"Максимальный вес: {_currentWeight}/{_inventoryMaxWeight}";  
        }


        
    }
    


}
