using _Project.Scripts.InventoryQuest;
using Scriptable_Objects;
using TMPro;
using UnityEngine;

namespace Items
{
    public class Book : Item
    {
        private const string ReadItStatus = "Прочитано";

        [SerializeField] private BookData _bookData;

        private bool _readIt;

        private void Awake()
        {
            base.Awake();
        
            WeightItem = _bookData.WeightItem;
            
            Stackable = _bookData.Stackable;
        }

        // public override void ClickAddItemPanelAction(SlotInventory slot)
        // {
        //     
        //     
        //     if (InventoryMenu.InventoryMaxWeight >= InventoryMenu.CurrentWeight + _bookData.WeightItem)
        //     {
        //         NewItem = Instantiate(gameObject, slot.transform);
        //         TextNewItem = NewItem.GetComponent<Book>().StatusText;
        //
        //         InventoryMenu.AddWeightInInventory(_bookData.WeightItem);
        //         TextNewItem.SetActive(true);
        //     }
        // }

        protected override void ClickInventoryPanelAction()
        {
            _readIt = true;
            StatusText.GetComponent<TMP_Text>().text = ReadItStatus;
        }
    }
}