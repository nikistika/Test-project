using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] internal HP_Panel panelHP;
    [SerializeField] internal GameObject StatusText;

    internal GameObject _parentObject;
    internal const string PANEL_ADD_ITEM = "PanelAddItem";
    internal const string PANEL_INVETNARY = "PanelInventary";
    internal const string FULL_STACK = "FullStack";

    internal GameObject newItem;
    internal GameObject textNewItem;

    internal bool Stackable;
    internal string ThisItemTag;

    internal Inventory InventoryObject => inventory;

    internal void Awake()
    {
        ThisItemTag = gameObject.tag;
    }


    public void OnClickIcon()
    {
        if (_parentObject.tag == PANEL_ADD_ITEM)
        {
            foreach (GameObject slot in inventory.Slots)
            {
                if (slot.transform.childCount == 1 && Stackable &&
                    !slot.transform.GetChild(0).CompareTag(tag: FULL_STACK))
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