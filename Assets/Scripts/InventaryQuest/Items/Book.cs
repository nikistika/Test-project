using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
 
    [SerializeField] private BookData _bookData;
    [SerializeField] private Inventary _inventary;

    private GameObject _parentObject;
    private const string PANEL_ADD_ITEM = "PanelAddItem";
    private const string PANEL_INVETNARY = "PanelInventary";
    
    private void Awake()
    {
        _parentObject = transform.parent.gameObject.transform.parent.gameObject;
    }
    
    public void OnClickIcon()
    {
        if (_parentObject.tag == PANEL_ADD_ITEM)
        {
            Instantiate(gameObject, _inventary.Slots[0].transform);
        }
        if (_parentObject.tag == PANEL_INVETNARY) ;
        
    }
    
}
