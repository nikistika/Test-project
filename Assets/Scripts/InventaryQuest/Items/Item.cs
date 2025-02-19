using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Inventary _inventary;
    [SerializeField] private GameObject _statusText;

    private GameObject _parentObject;
    internal const string PANEL_ADD_ITEM = "PanelAddItem";
    internal const string PANEL_INVETNARY = "PanelInventary";

    internal GameObject newItem;
    internal GameObject textNewItem;

    internal Inventary InventaryObject => _inventary;
    public GameObject StatusText => _statusText;

    private void Awake()
    {
        _parentObject = transform.parent.gameObject.transform.parent.gameObject;
    }

    public void OnClickIcon()
    {
        if (_parentObject.tag == PANEL_ADD_ITEM)
        {
            foreach (GameObject slot in _inventary.Slots)
            {
                if (slot.transform.childCount == 0)
                {
                    AddItemPanelAction(slot);
                    break;
                }
            }

        }
        if (_parentObject.tag == PANEL_INVETNARY)
        {

        }
    }

    internal virtual void AddItemPanelAction(GameObject slot)
    {

    }

    internal virtual void InventaryPanelAction()
    {

    }


}
