using TMPro;
using UnityEngine;

namespace InventaryQuest.Items
{
    public class Potion : Item
    {
        
        [SerializeField] private PotionData _potionData;
        private int _currentCount;
        
        public int CurrentCount => _currentCount;

        private void Awake()
        {
            base.Awake();
            Debug.Log($"_parentObject: {_parentObject}");
            Debug.Log($"StatusText: {StatusText}");
            Stackable = _potionData.Stackable;
        }
            
        internal override void ClickAddItemPanelAction(GameObject slot)
        {
            if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _potionData.WeightItem)
            {
                newItem = Instantiate(gameObject, slot.transform);
                textNewItem = newItem.GetComponent<Potion>().StatusText;

                InventoryObject.AddWeightInInventory(_potionData.WeightItem);
                textNewItem.SetActive(true);
            }
        }
        
        internal override void ClickAddItemPanelAction(GameObject slot, int quantityItem)
        {

            slot.transform.GetChild(0).gameObject.GetComponent<Potion>()._currentCount += quantityItem;
            StatusText.GetComponent<TMP_Text>().text = $"{_currentCount}/{_potionData.MaxCount}";
            //TODO: Дописать эту функцию

        }

        internal override void ClickInventoryPanelAction()
        {
            
        }
        
    }
}