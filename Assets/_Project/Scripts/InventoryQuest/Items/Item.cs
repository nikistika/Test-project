using _Project.Scripts.InventoryQuest;
using InventoryUI;
using UI;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        protected const string PANEL_ADD_ITEM = "PanelAddItem";
        protected const string PANEL_INVETNARY = "PanelInventary";
        protected const string FULL_STACK = "FullStack";

        
        protected HP_Panel PanelHP;
        [SerializeField] protected GameObject StatusText;

        protected GameObject ParentObject;
        protected GameObject NewItem;
        protected GameObject TextNewItem;

        protected RightHandState RightHand;
        
        protected bool Stackable;
        protected string ThisItemTag;
        
        public float WeightItem { get; protected set; }
        [field: SerializeField] protected InventoryMenu InventoryMenu { get; private set; }

        protected void Awake()
        {
            ThisItemTag = gameObject.tag;
        }

        public void Construct(HP_Panel hpPanel, InventoryMenu inventoryMenu, RightHandState rightHandRight)
        {
            PanelHP = hpPanel;
            InventoryMenu = inventoryMenu;
            RightHand = rightHandRight;
        }
        
        public void OnClickIcon()
        {
            // if (ParentObject.tag == PANEL_ADD_ITEM)
            // {
            //     foreach (GameObject slot in InventoryMenu.Slots)
            //     {
            //         if (slot.transform.childCount == 1 && Stackable &&
            //             !slot.transform.GetChild(0).CompareTag(tag: FULL_STACK))
            //         {
            //             string objectTag = slot.transform.GetChild(0).tag;
            //             if (Stackable && objectTag == ThisItemTag)
            //             {
            //                 ClickAddItemPanelAction(slot, 1);
            //                 break;
            //             }
            //         }
            //
            //         if (slot.transform.childCount == 0 && Stackable)
            //         {
            //             ClickAddItemPanelAction(slot);
            //             break;
            //         }
            //
            //         if (slot.transform.childCount == 0 && !Stackable)
            //         {
            //             ClickAddItemPanelAction(slot);
            //             break;
            //         }
            //     }
            // }
            //
            // if (ParentObject.tag == PANEL_INVETNARY)
            // {
            //     ClickInventoryPanelAction();
            // }
        }

        public void ClickAddItemPanelAction(SlotInventory slot, Item item)
        {
            slot.AddNewItemInCurrentSlot(item);
        }

        protected virtual void ClickInventoryPanelAction()
        {
        }

        public virtual void ClickAddItemPanelAction(GameObject slot, int quantityItem)
        {
        }
    }
}