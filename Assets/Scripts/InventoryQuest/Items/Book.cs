using TMPro;
using UnityEngine;

public class Book : Item
{
    private const string ReadItStatus = "Прочитано";
    private bool _readIt;

    [SerializeField] private BookData _bookData;

    private void Awake()
    {
        base.Awake();

        Stackable = _bookData.Stackable;
    }

    internal override void ClickAddItemPanelAction(GameObject slot)
    {
        if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _bookData.WeightItem)
        {
            newItem = Instantiate(gameObject, slot.transform);
            textNewItem = newItem.GetComponent<Book>().StatusText;

            InventoryObject.AddWeightInInventory(_bookData.WeightItem);
            textNewItem.SetActive(true);
        }
    }

    internal override void ClickInventoryPanelAction()
    {
        _readIt = true;
        StatusText.GetComponent<TMP_Text>().text = ReadItStatus;
    }
}