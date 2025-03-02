using System;
using System.Collections.Generic;
using InventoryUI;
using Items;
using UI;
using UnityEngine;

namespace _Project.Scripts.InventoryQuest
{
    public class EntryPointScaneInventory : MonoBehaviour
    {
        
        [SerializeField] private PanelAddItem _panelAddItem;
        [SerializeField] private InventoryMenu _inventoryMenu;

        [SerializeField] private HP_Panel _hpPanel;
        [SerializeField] private RightHandState _rightHand;
        
        [SerializeField] private List<Item> _items;
        
        [SerializeField] private List<SlotAddItem> _slotAddItems;
        
        private void Awake()
        {

            foreach (var item in _items)
            {
                item.Construct(_hpPanel, _inventoryMenu, _rightHand);
            }

            foreach (var slot in _slotAddItems)
            {
                slot.Construct(_inventoryMenu);   
            }
            
            _panelAddItem.Construct(_items);
            
        }
        
    }
}