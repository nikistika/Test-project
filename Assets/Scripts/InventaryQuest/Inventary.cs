using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventary : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> _slots = new List<GameObject>();
    [SerializeField] private TMP_Text _countWeightText;
    
    public List<GameObject> Slots => _slots;
    
    public void AddItem(Item item)
    {
        
    }

    public void OpenCloseInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf); 
    }
    
}
