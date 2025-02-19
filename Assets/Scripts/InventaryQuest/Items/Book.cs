using TMPro;
using UnityEngine;

public class Book : Item
{

    private bool _readIt;
    
    [SerializeField] private BookData _bookData;

    internal override void ClickAddItemPanelAction(GameObject slot)
    {
        if (InventoryObject.InventoryMaxWeight > InventoryObject.CurrentWeight)
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
        Debug.Log($"textNewItem in ClickInventoryPanelAction {textNewItem}");

        StatusText.GetComponent<TMP_Text>().text = "Прочитано";
    }

}
