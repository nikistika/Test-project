using InventaryQuest.Items;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PanelAddItem _panelAddItem;
    private Inventory _inventory;

    private void Awake()
    {
        _panelAddItem = GameObject.Find("PanelAddItem").GetComponent<PanelAddItem>();
        Debug.Log($"_panelAddItem: {_panelAddItem}");
        _inventory = GameObject.Find("InventaryMenu").GetComponent<Inventory>();
    }

    public void ReturnItemInInventory()
    {
        GameObject freeSlot = ScanSlots();

        if (gameObject.name == "Mace(Clone)")
        {
            Mace mace = _panelAddItem.items[3].GetComponent<Mace>();
            if (mace == null)
            {
                return;
            }

            mace.ClickAddItemPanelAction(freeSlot);
        }

        if (gameObject.name == "Shield(Clone)")
        {
            Shield shield = _panelAddItem.items[2].GetComponent<Shield>();
            shield.ClickAddItemPanelAction(freeSlot);

            if (shield == null)
            {
                return;
            }
        }

        Destroy(gameObject);
    }

    private GameObject ScanSlots()
    {
        foreach (GameObject slot in _inventory.Slots)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }

        return null;
    }
}