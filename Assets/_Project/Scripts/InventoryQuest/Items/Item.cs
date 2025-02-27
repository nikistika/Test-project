using InventoryUI;
using UI;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        internal const string PANEL_ADD_ITEM = "PanelAddItem";
        internal const string PANEL_INVETNARY = "PanelInventary";
        internal const string FULL_STACK = "FullStack";
        
        [SerializeField] internal HP_Panel PanelHP;
        [SerializeField] internal GameObject StatusText;

        internal GameObject ParentObject;
        internal GameObject NewItem;
        internal GameObject TextNewItem;
        internal bool Stackable;
        internal string ThisItemTag;
        
        [field: SerializeField] internal Inventory InventoryObject { get; private set; }

        protected void Awake()
        {
            ThisItemTag = gameObject.tag;
        }
        
        public void OnClickIcon()
        {
            if (ParentObject.tag == PANEL_ADD_ITEM)
            {
                foreach (GameObject slot in InventoryObject.Slots)
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

            if (ParentObject.tag == PANEL_INVETNARY)
            {
                ClickInventoryPanelAction();
            }
        }

        public virtual void ClickAddItemPanelAction(GameObject slot)
        {
        }

        protected virtual void ClickInventoryPanelAction()
        {
        }

        public virtual void ClickAddItemPanelAction(GameObject slot, int quantityItem)
        {
        }
    }
}