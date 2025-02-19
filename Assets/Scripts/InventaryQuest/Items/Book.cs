using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Book : Item
{
       

    [SerializeField] private BookData _bookData;

    internal override void AddItemPanelAction(GameObject slot)
    {
        newItem = Instantiate(gameObject, slot.transform);
        textNewItem = newItem.GetComponent<Book>().StatusText.gameObject;
        InventaryObject.AddWeightInInventory(_bookData.WeightItem);
        textNewItem.SetActive(true);
    }

    internal override void InventaryPanelAction()
    {

    }

}
