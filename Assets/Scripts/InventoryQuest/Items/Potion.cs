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
            Stackable = _potionData.Stackable;
        }
            
        internal override void ClickAddItemPanelAction(GameObject slot)
        {
            if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _potionData.WeightItem)
            {
                newItem = Instantiate(gameObject, slot.transform);
                newItem.GetComponent<Potion>()._currentCount = 1;
                newItem.GetComponent<Potion>().StatusText.GetComponent<TMP_Text>().text = $"{newItem.GetComponent<Potion>()._currentCount}/{_potionData.MaxCount}";
                textNewItem = newItem.GetComponent<Potion>().StatusText;

                InventoryObject.AddWeightInInventory(_potionData.WeightItem);
                textNewItem.SetActive(true);
            }
        }
        
        internal override void ClickAddItemPanelAction(GameObject slot, int quantityItem)
        {
            if (InventoryObject.InventoryMaxWeight >= InventoryObject.CurrentWeight + _potionData.WeightItem)
            {
                var potion = slot.transform.GetChild(0).gameObject.GetComponent<Potion>();
                // potion = (potion == null) ? return : potion.GetComponent<Potion>();
                if (potion._currentCount + quantityItem <= _potionData.MaxCount)
                {
                    potion._currentCount += quantityItem;
                    InventoryObject.AddWeightInInventory(_potionData.WeightItem);

                    potion.StatusText.GetComponent<TMP_Text>().text = $"{potion._currentCount}/{_potionData.MaxCount}";

                }
                else if (potion._currentCount + quantityItem > _potionData.MaxCount)
                {
                    potion.gameObject.tag = FULL_STACK;
                    OnClickIcon();
                }
            }

        }

        internal override void ClickInventoryPanelAction()
        {
            panelHP.Heal(_potionData.HealQuantity);
            _currentCount -= 1;
            InventoryObject.RemoveInFroInventory(_potionData.WeightItem);
            if (_currentCount <= 0) Destroy(gameObject);
            StatusText.GetComponent<TMP_Text>().text = $"{_currentCount}/{_potionData.MaxCount}";
        }
        
    }
}