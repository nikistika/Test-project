using TMPro;
using UnityEngine;

namespace InventaryQuest.Items
{
    public class Potion : Item
    {
        
        [SerializeField] private PotionData _potionData;
        public int _currentCount;
        

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

            var potion = slot.transform.GetChild(0).gameObject.GetComponent<Potion>();
            if (potion._currentCount + quantityItem <= _potionData.MaxCount) potion._currentCount += quantityItem;
            potion.StatusText.GetComponent<TMP_Text>().text = $"{potion._currentCount}/{_potionData.MaxCount}";

        }

        internal override void ClickInventoryPanelAction()
        {
            
        }
        
    }
}