using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventary : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> _slots = new List<GameObject>();
    [SerializeField] private float _inventaryMaxWeight;
    [SerializeField] private TMP_Text _countWeightText;
    
    public List<GameObject> Slots => _slots;
    
    public void AddItem(Item item)
    {
        
    }

    public void OpenCloseInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf); 
    }

    public void AddWeightInInventory(float weight)
    {
        _inventaryMaxWeight += weight;
    }

        public void AddWeightInFromventory(float weight)
    {
        _inventaryMaxWeight -= weight;
    }
    


}
