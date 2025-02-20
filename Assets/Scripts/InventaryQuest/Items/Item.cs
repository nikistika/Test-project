using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] internal GameObject StatusText;

    internal GameObject _parentObject;
    internal const string PANEL_ADD_ITEM = "PanelAddItem";
    internal const string PANEL_INVETNARY = "PanelInventary";

    internal GameObject newItem;
    internal GameObject textNewItem;

    internal bool Stackable;
    internal string ThisItemTag;
    
    internal Inventory InventoryObject => inventory;

    internal void Awake()
    {
        ThisItemTag = gameObject.tag;
        _parentObject = transform.parent.gameObject.transform.parent.gameObject;
        
        
        // StatusText = gameObject.GetComponentInChildren<TMP_Text>().gameObject;
        // StatusText = transform.GetChild(0).gameObject;
        
    }
    
    
    public void OnClickIcon()
    {
        if (_parentObject.tag == PANEL_ADD_ITEM)
        {
            foreach (GameObject slot in inventory.Slots)
            {

                if (slot.transform.childCount == 1 && Stackable)
                {
                    string objectTag = slot.transform.GetChild(0).tag;
                    if (Stackable && objectTag == ThisItemTag)
                    {
                        ClickAddItemPanelAction(slot, 1);
                        break;
                    }
                }

                if (slot.transform.childCount == 0 && Stackable)
                {
                    ClickAddItemPanelAction(slot);
                    break;  
                }
                
                if (slot.transform.childCount == 0 && !Stackable)
                {
                    ClickAddItemPanelAction(slot);
                    break;
                }
            }

        }
        if (_parentObject.tag == PANEL_INVETNARY)
        {
            ClickInventoryPanelAction();
        }
    }

    internal virtual void ClickAddItemPanelAction(GameObject slot)
    {

    }

    internal virtual void ClickInventoryPanelAction()
    {

    }

    internal virtual void ClickAddItemPanelAction(GameObject slot, int quantityItem)
    {
        
    }


}
