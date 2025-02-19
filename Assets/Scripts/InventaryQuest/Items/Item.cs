using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    internal GameObject StatusText;

    private GameObject _parentObject;
    internal const string PANEL_ADD_ITEM = "PanelAddItem";
    internal const string PANEL_INVETNARY = "PanelInventary";

    internal GameObject newItem;
    internal GameObject textNewItem;

    internal Inventory InventoryObject => inventory;

    private void Awake()
    {
        _parentObject = transform.parent.gameObject.transform.parent.gameObject;
        StatusText = transform.GetChild(0).gameObject;
        Debug.Log($"Awake {StatusText}");
    }
    
    
    public void OnClickIcon()
    {
        if (_parentObject.tag == PANEL_ADD_ITEM)
        {
            foreach (GameObject slot in inventory.Slots)
            {
                if (slot.transform.childCount == 0)
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


}
